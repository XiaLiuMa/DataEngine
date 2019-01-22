using DataEngine.Common;
using Microsoft.AspNetCore.Hosting;
using Schedule.Engine.Core;
using System;
using System.IO;

namespace DataEngine.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Logger.Init(AppDomain.CurrentDomain.BaseDirectory + @"Configs\Log4Net.config"); //初始化日志工具
            System.Threading.Mutex mutex = new System.Threading.Mutex(false, "DataEngine.Service");
            bool Running = !mutex.WaitOne(0, false);
            GlobalManament.GetInstance().RunConfigJobs();
            if (!Running)
            {
                int port = GlobalManament.GetInstance().serviceConfig.ServicePort;
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseUrls($"http://localhost:{port}")
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();
                host.Run();
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Error(e.ExceptionObject.ToString());
            Environment.Exit(0);
        }
    }
}
