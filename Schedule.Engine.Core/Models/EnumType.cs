using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Engine.Core.Models
{
    /// <summary>
	/// 枚举类型
	/// </summary>
	public class EnumType
    {
        public enum JobStatus
        {
            Running = 0,    //运行中
            Paused = 1, //暂停状态
        }
    }
}
