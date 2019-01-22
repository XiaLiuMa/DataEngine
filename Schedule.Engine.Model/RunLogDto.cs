using System;

namespace Schedule.Engine.Model
{
    /// <summary>
    /// 运行日志
    /// </summary>
    public class RunLogDto
    {
        /// <summary>
        /// 调度任务名称
        /// </summary>
        public string JobName { get; set; }

        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string ReMark { get; set; }
    }
}
