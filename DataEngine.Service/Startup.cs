using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Nancy.Owin;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;
using DataEngine.Db.IManaments;
using DataEngine.Db.Manaments;
using System.Threading.Tasks;

namespace DataEngine.Service
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            //BaseMapper.Initialize();    //初始化映射关系
        }

        /// <summary>
        /// 此方法由运行时调用。使用此方法将服务添加到容器中。
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            //依赖注入
            services.AddScoped<IScheduleManament, ScheduleManament>();
            services.AddScoped<ISqlManament, SqlManament>();
        }

        /// <summary>
        /// 此方法由运行时调用。使用此方法配置HTTP请求管道
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
            });//使用静态文件
            app.UseOwin(x => x.UseNancy());
        }
    }
}
