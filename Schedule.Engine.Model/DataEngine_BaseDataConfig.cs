//using Schedule.model.common;
//using System;
//using System.Collections.Generic;
//using System.Runtime.Caching;

//namespace Schedule.Engine.Model
//{
//    /// <summary>
//    /// DataEngine基础数据配置
//    /// </summary>
//    public class DataEngine_BaseDataConfig
//    {
//        private static MemoryCache _ConfigCache = new MemoryCache("BaseData");
//        private static readonly string baseDataConfigPath = @"config\BaseData.xml";

//        public static BaseData baseDataConfig
//        {
//            get
//            {
//                var mqconfig = (BaseData)_ConfigCache.Get("BaseData");
//                if (mqconfig == null)
//                {
//                    mqconfig = SerializationHelper.Load<BaseData>(AppDomain.CurrentDomain.BaseDirectory + baseDataConfigPath);

//                    var policy = new CacheItemPolicy();

//                    policy.ChangeMonitors.Add(new HostFileChangeMonitor(new List<string>() { AppDomain.CurrentDomain.BaseDirectory + baseDataConfigPath }));
//                    _ConfigCache.Add("BaseData", mqconfig, policy);
//                }
//                return mqconfig;
//            }
//        }
//    }

//    public class BaseData
//    {
//        /// <summary>
//        /// 要做操作员时间统计的部门代码
//        /// </summary>
//        public string Czysjtjdm { get; set; }

//        /// <summary>
//        /// 一次最大发送记录数
//        /// </summary>
//        public string MaxSendCount { get; set; }

//        /// <summary>
//        /// 统计间隔时间，单位：分钟:出入境人员、出入境交通工具
//        /// </summary>
//        public string TJJGSJ { get; set; }

//        /// <summary>
//        /// Access数据库绝对路径
//        /// </summary>
//        public string IsolatorDbStr { get; set; }

//        /// <summary>
//        /// 运行日志保存天数
//        /// </summary>
//        public string RunLogDays { get; set; }

//        /// <summary>
//        /// 72小时过境免签逾期旅客人数
//        /// </summary>
//        public string Sthtft { get; set; }
//    }
//}
