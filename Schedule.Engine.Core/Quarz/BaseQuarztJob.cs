using DataEngine.Db.IManaments;
using Quartz;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Schedule.Engine.Core.Quarz
{
//    public class BaseQuarztJob : IJob
//    {
//        private readonly ISqlManament sqlManament;
//        public BaseQuarztJob(ISqlManament _manament)
//        {
//            sqlManament = _manament;
//        }


//        // public properties...
//        public List<ISqlOperate> LstSqlOperate { get; set; }

//        public AbstractQuarztJob()
//        {
//        }

//        // private methods...
//        /// <summary>
//        /// 初始化当前类以及属性变量获取
//        /// </summary>
//        /// <param name="context"></param>
//        private void Init(IJobExecutionContext context)
//        {
//            LstSqlOperate = context.JobDetail.JobDataMap["ISqlOperate"] as List<ISqlOperate>;
//        }

//        System.Diagnostics.Stopwatch st = new System.Diagnostics.Stopwatch();
//        RunLogDto dt = new RunLogDto();
//        string _ClassNote;

//        // public methods...
//        public void Execute(IJobExecutionContext context)
//        {
//            try
//            {
//                if (context.JobDetail.JobDataMap["IsRuning"].ToString().Equals("true"))
//                {
//                    return;
//                }
//                context.JobDetail.JobDataMap["IsRuning"] = "true";

//                Init(context);
//                _ClassNote = context.JobDetail.JobDataMap["ClassNote"].ToString();
//#if DEBUG
//                LogHelp.Info(DateTime.Now.ToString() + ":开始执行，" + _ClassNote);
//#endif

//                dt.JobName = _ClassNote;
//                dt.StartTime = DateTime.Now;
//                st.Start();
//                Run(context);
//                st.Stop();
//                dt.EndTime = DateTime.Now;
//                dt.ReMark = dt.JobName + "，本次执行用时:" + st.ElapsedMilliseconds + "毫秒";
//                //JobLogHelper.AddRunLog(dt);
//#if DEBUG
//                LogHelp.Info(DateTime.Now.ToString() + ":执行完成，" + _ClassNote + "用时:" + st.ElapsedMilliseconds + "毫秒");
//#endif
//            }
//            catch (Exception ex)
//            {
//                LogHelp.Error(this.GetType(), ex);
//            }
//            finally
//            {
//                context.JobDetail.JobDataMap["IsRuning"] = "false";
//            }
//        }
//        /// <summary>
//        /// 任务执行方法
//        /// </summary>
//        public abstract void Run(IJobExecutionContext context);

//        Task IJob.Execute(IJobExecutionContext context)
//        {
//            throw new NotImplementedException();
//        }
//    }
}
