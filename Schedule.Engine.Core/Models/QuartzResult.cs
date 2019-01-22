using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.Engine.Core.Models
{
    public class QuartzResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Msg { get; set; }
    }
}
