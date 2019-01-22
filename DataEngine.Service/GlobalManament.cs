using DataEngine.Common;
using DataEngine.Service.Models;
using Schedule.Engine.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataEngine.Service
{
    public class GlobalManament
    {
        public ServiceConfig serviceConfig { get; private set; }
        public ServicePrivateConfig privateConfig { get; private set; }
        private static GlobalManament instance;
        private readonly static object objLock = new object();
        public static GlobalManament GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new GlobalManament();
                    }
                }
            }
            return instance;
        }
        public GlobalManament()
        {
            string strConfig = AppDomain.CurrentDomain.BaseDirectory + @"Configs\ServiceConfig.xml";
            serviceConfig = XmlSerializer.Load<ServiceConfig>(strConfig);
        }

        public void RunConfigJobs()
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5 * 1000);
                //运行配置文件中的工作计划
                JobManager.GetInstance().RunConfigJobs(AppDomain.CurrentDomain.BaseDirectory + @"Configs\QuartzByCron.xml");
            });
        }
    }
}
