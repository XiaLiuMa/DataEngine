using DataEngine.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataEngine.Db
{
    public class BaseDBContext : DbContext
    {

        private static BaseDBContext instance;
        private readonly static object objLock = new object();
        public static BaseDBContext GetInstance()
        {
            if (instance == null)
            {
                lock (objLock)
                {
                    if (instance == null)
                    {
                        instance = new BaseDBContext();
                    }
                }
            }
            return instance;
        }

        public DbSet<ScheduleEntity> Schedules { get; set; }

        public DbSet<object> Objs { get; set; }

        public DbSet<SqlEntity> Sqls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(@"Server=localhost;User Id=sa;Password=123456;Database=Db_Quartz"); //注入mySql链接字符串
        }

    }
}
