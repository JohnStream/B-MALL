using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using B_MALL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using B_MALL.Services;
using AutoMapper;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;

namespace B_MALL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 依赖注入
            // Transient： 每一次GetService都会创建一个新的实例
            // Scoped：  在同一个Scope内只初始化一个实例 ，可以理解为（ 每一个request级别只创建一个实例，同一个http request会在一个 scope内）
            // Singleton ：整个应用程序生命周期以内只创建一个实例
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccountService, AccountService>();
            // 默认数据库连接
            services.AddDbContext<UserContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            // Swagger webapi文档工具
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "MALL Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "MALL" }
                });
            });
            // Session服务
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Session服务
            app.UseSession();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
