using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Engine.Core.Models
{
    /// <summary>
    /// 任务调度实体集合
    /// </summary>
    public class Schedulers
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        public List<Scheduler> SchedulerList { get; set; }
    }
    /// <summary>
    /// 任务调度实体
    /// </summary>
    public class Scheduler
    {
        /// <summary>
        /// 任务编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 任务分组
        /// </summary>
        public string JobGroup { get; set; }
        /// <summary>
        /// 执行周期表达式
        /// </summary>
        public string Cron { get; set; }
        /// <summary>
        /// 任务所在DLL对应的程序集名称
        /// </summary>
        public string AssemblyName { get; set; }
        /// <summary>
        /// 任务所在类名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 任务描述
        /// </summary>
        public string Remark { get; set; }
    }
}
