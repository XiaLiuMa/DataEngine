using DataEngine.Common;
using Quartz;
using Schedule.Engine.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Schedule.Engine.Core
{
    /// <summary>
    /// 工作计划管理员
    /// </summary>
    public class JobManager
    {
        private static JobManager instance;
        private readonly static object objLock = new object();
        public static JobManager GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new JobManager();
                    }
                }
            }
            return instance;
        }

        /// <summary>
        /// 运行配置的工作计划
        /// </summary>
        /// <param name="config"></param>
        public void RunConfigJobs(string config)
        {
            try
            {
                var tempList = XmlSerializer.Load<Schedulers>(config);
                foreach (var item in tempList.SchedulerList)
                {
                    var tempResult = SchedulerCenter.GetInstance().RunScheduleJob(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString());
            }
        }

        /// <summary>
        /// 获取项目中所有继承了IJober接口的类
        /// </summary>
        /// <returns></returns>
        public Type[] GetTypesBy_IJob()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IJob)))).ToArray();
        }


    }
}
