using DataEngine.Common;
using Quartz;
using Quartz.Impl;
using Schedule.Engine.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.Engine.Core
{
    /// <summary>
    /// 任务调度中心
    /// </summary>
    public class SchedulerCenter
    {
        private static SchedulerCenter instance;
        private readonly static object objLock = new object();
        public static SchedulerCenter GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new SchedulerCenter();
                    }
                }
            }
            return instance;
        }
        public List<Scheduler> ScheduleList = new List<Scheduler>(); //任务计划列表

        //private IScheduler _scheduler;
        ///// <summary>
        ///// 任务调度器
        ///// </summary>
        ///// <returns></returns>
        //private IScheduler Scheduler
        //{
        //    get
        //    {
        //        if (this._scheduler != null) return this._scheduler;

        //        NameValueCollection props = new NameValueCollection
        //        {
        //            { "quartz.serializer.type", "binary" }
        //        };
        //        StdSchedulerFactory factory = new StdSchedulerFactory(props);
        //        return this._scheduler = factory.GetScheduler().Result;    //从Factory中获取Scheduler实例
        //    }
        //}

        private Task<IScheduler> _scheduler;
        /// <summary>
        /// 任务调度器
        /// </summary>
        /// <returns></returns>
        private Task<IScheduler> Scheduler
        {
            get
            {
                if (this._scheduler != null)
                {
                    return this._scheduler;
                }
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                return this._scheduler = factory.GetScheduler();    //从Factory中获取Scheduler实例
            }
        }

        /// <summary>
        /// 停止任务调度器
        /// </summary>
        public async void StopScheduleAsync()
        {
            if (!this.Scheduler.Result.IsShutdown) await this.Scheduler.Result.Shutdown();
        }

        /// <summary>
        /// 运行指定的计划
        /// </summary>
        /// <param name="schedule">jobId</param>
        /// <returns></returns>
        public async Task<QuartzResult> RunScheduleJob(Scheduler schedule)
        {
            QuartzResult result;
            if (!this.Scheduler.Result.IsStarted) await this.Scheduler.Result.Start();
            var runResult = await Task.Factory.StartNew(async () =>
            {
                var tempResult = new QuartzResult();
                try
                {
                    string _AssemblyName = AppDomain.CurrentDomain.BaseDirectory + schedule.AssemblyName;
                    var jobType = AssemblyHandler.GetClassType(_AssemblyName, schedule.ClassName);  //反射获取任务执行类
                    IJobDetail job = new JobDetailImpl(schedule.JobName, schedule.JobGroup, jobType);   // 定义这个工作，并将其绑定到IJob实现类
                    ITrigger trigger = CreateCronTrigger(schedule);   // 创建触发器
                    await this.Scheduler.Result.ScheduleJob(job, trigger);  // 告诉Quartz使用我们的触发器来安排作业

                    tempResult.Code = 1000;
                    ScheduleList.Add(schedule);
                }
                catch (Exception ex)
                {
                    tempResult.Code = 1001;
                    tempResult.Msg = ex.Message;
                }
                return tempResult;
            });

            if (runResult.Result.Code == 1000)
            {
                await this.Scheduler.Result.ResumeJob(new JobKey(schedule.JobName, schedule.JobGroup));   //用给定的密钥恢复（取消暂停）IJobDetail
                result = new QuartzResult
                {
                    Code = 1000,
                    Msg = "启动成功"
                };
            }
            else
            {
                result = new QuartzResult
                {
                    Code = -1
                };
            }
            return result;
        }

        /// <summary>
        /// 停止指定的计划
        /// </summary>
        /// <param name="jobId">jobId</param>
        /// <param name="isDelete">停止并删除任务</param>
        /// <returns></returns>
        public async Task<QuartzResult> StopScheduleJob(Guid jobId, bool isDelete = false)
        {
            if (!this.Scheduler.Result.IsStarted) await this.Scheduler.Result.Start();
            QuartzResult result;
            try
            {
                Scheduler schedule = ScheduleList.Where(p => p.Id.Equals(jobId)).FirstOrDefault(); //获取任务实例
                await this.Scheduler.Result.PauseJob(new JobKey(schedule.JobName, schedule.JobGroup));
                if (isDelete) ScheduleList.Remove(schedule); //从列表移除
                result = new QuartzResult
                {
                    Code = 1000,
                    Msg = "停止任务计划成功！"
                };
            }
            catch (Exception ex)
            {
                result = new QuartzResult
                {
                    Code = -1,
                    Msg = ex.Message
                };
            }
            return result;
        }

        /// <summary>
        /// 恢复运行(被暂停的)计划
        /// </summary>
        /// <param name="jobId">jobId</param>
        public async void ResumeJob(Guid jobId)
        {
            if (!this.Scheduler.Result.IsStarted) await this.Scheduler.Result.Start();
            try
            {
                Scheduler schedule = ScheduleList.Where(p => p.Id.Equals(jobId)).FirstOrDefault(); //获取任务实例
                var jk = new JobKey(schedule.JobName, schedule.JobGroup);
                if (await this.Scheduler.Result.CheckExists(jk))    //检查任务是否存在
                {
                    await this.Scheduler.Result.ResumeJob(jk);
                    await Console.Out.WriteLineAsync(string.Format("任务“{0}”恢复运行", schedule.JobName));
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(string.Format("恢复任务失败！{0}", ex));
            }
        }

        /// <summary>
        /// 创建类型Cron的触发器
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private ITrigger CreateCronTrigger(Scheduler m)
        {
            // 作业触发器
            return TriggerBuilder.Create()
                   .WithIdentity(m.JobName, m.JobGroup)
                   .WithCronSchedule(m.Cron)//指定cron表达式
                   .ForJob(m.JobName, m.JobGroup)//作业名称
                   .Build();
        }
    }
}
