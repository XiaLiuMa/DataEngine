﻿using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DataEngine.Service
{
    public class CRJRYJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            string filePath = @"C:\Users\XiaLM\Desktop\text.txt";
            string tempStr = File.ReadAllText(filePath) + $"|{DateTime.Now.ToString("YYYYmmDDHHmmss")}";
            File.WriteAllText(filePath, tempStr);
            return Task.CompletedTask;
        }
    }
}
