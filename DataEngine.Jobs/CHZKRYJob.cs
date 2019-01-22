using DataEngine.Common;
using DataEngine.Db;
using DataEngine.Db.IManaments;
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DataEngine.Jobs
{
    public class CHZKRYJob : IJob
    {
        private readonly ISqlManament sqlManament;
        public CHZKRYJob(ISqlManament _manament)
        {
            sqlManament = _manament;
        }

        public Task Execute(IJobExecutionContext context)
        {
            string filePath = @"C:\Users\XiaLM\Desktop\text.txt";
            string tempStr = File.ReadAllText(filePath) + $"|{DateTime.Now.ToString("YYYYmmDDHHmmss")}";
            File.WriteAllText(filePath, tempStr);

            string strSql = sqlManament.FirstOrDefault(p => p.SqlName.Equals("CHZKRYJL")).SqlText;
            string sql = string.Format(strSql, DateTime.Now.ToString("yyyyMMdd000000"), DateTime.Now.ToString("yyyyMMdd235959"));
            var result = BaseDBContext.GetInstance().Database.SqlQuery<object>(sql);   //执行sql语句
            return Task.CompletedTask;
        }
    }
}
