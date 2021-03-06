using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.Swagger;
using System.Threading.Tasks;
using WebApiMultilayer.BLL.DTO;
using WebApiMultilayer.BLL.Infrastructure;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(options =>
                {
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    options.UseSqlServer(connection);
                });

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;   // ����������� �����
                options.Password.RequireNonAlphanumeric = false;   // ��������� �� �� ���������-�������� �������
                options.Password.RequireLowercase = false; // ��������� �� ������� � ������ ��������
                options.Password.RequireUppercase = false; // ��������� �� ������� � ������� ��������
                options.Password.RequireDigit = false; // ��������� �� �����
            }).AddEntityFrameworkStores<ApplicationContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IService<MarkDTO>, MarkService>();
            services.AddTransient<IService<ModelDTO>, ModelService>();
            services.AddTransient<IService<AttachmentDTO>, AttachmentService>();
            services.AddTransient<IService<AutoDTO>, AutoService>();
            services.AddTransient<IUserService, UserService>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(options =>
                {
                    options.OperationFilter<FileUploadOperation>();
                });

            services.ConfigureSwaggerGen(options =>
            {
                options.OperationFilter<FileUploadOperation>(); //Register File Upload Operation Filter
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty;
            });
        }
    }
}
