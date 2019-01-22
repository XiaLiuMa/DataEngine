using System;
using System.Collections.Generic;
using System.Text;

namespace DataEngine.Service.Models
{
    public class ServicePrivateConfig
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string DbConnectionStr { get; private set; } = @"Server=localhost;User Id = sa; Password=123456;Database=Db_Quartz";
    }
}
