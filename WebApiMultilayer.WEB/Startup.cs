using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.BLL.Interfaces;
using WebApiMultilayer.BLL.Services;
using WebApiMultilayer.DAL;
using WebApiMultilayer.DAL.Entities;
using WebApiMultilayer.DAL.Interfaces;
using WebApiMultilayer.DAL.Repositories;

namespace WebApiMultilayer.WEB
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IService<MarkDTO>, MarkService>();

            services.AddControllers();

            services.AddSwaggerGen();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
