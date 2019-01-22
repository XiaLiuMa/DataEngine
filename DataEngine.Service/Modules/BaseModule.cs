using Nancy;
using Schedule.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEngine.Service.Modules
{
    public class BaseModule : NancyModule
    {
        public BaseModule()
        {
            Get("/", args => "默认地址");
            Get("/GetAllRuningJob", p => GetAllRuningJob());
        }

        /// <summary>
        /// 获取正在运行的Jobs
        /// </summary>
        /// <returns></returns>
        private object GetAllRuningJob()
        {
            return SchedulerCenter.GetInstance().ScheduleList;
        }

    }
}
