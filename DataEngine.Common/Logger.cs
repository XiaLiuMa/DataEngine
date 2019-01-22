using log4net;
using log4net.Config;
using System;
using System.IO;

namespace DataEngine.Common
{
    public class Logger
    {
        private static ILog logger;
        /// <summary>
        /// 初始化日志配置文件
        /// </summary>
        /// <param name="config"></param>
        public static void Init(string config)
        {
            if (logger == null)
            {
                var repository = LogManager.CreateRepository("NETCoreRepository");
                XmlConfigurator.Configure(repository, new FileInfo(config));  //log4net从log4net.config文件中读取配置信息
                logger = LogManager.GetLogger(repository.Name, "InfoLogger");
            }
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Info(string message, Exception exception = null)
        {
            if (exception == null) logger.Info(message);
            if (exception != null) logger.Info(message, exception);
        }

        /// <summary>
        /// 告警日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Warn(string message, Exception exception = null)
        {
            if (exception == null) logger.Warn(message);
            if (exception != null) logger.Warn(message, exception);
        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception = null)
        {
            if (exception == null) logger.Error(message);
            if (exception != null) logger.Error(message, exception);
        }
    }
}
