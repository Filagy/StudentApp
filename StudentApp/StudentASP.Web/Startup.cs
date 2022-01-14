using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StudentASP.Application.Services;
using StudentASP.DataAccess.MSSQL;
using StudentASP.DataAccess.MSSQL.Repository;
using StudentASP.Domain.Interfaces;
using StudentASP.Domain.Repositories;
using StudentASP.Domain.Services;
using System.IO;

namespace StudentASP.Web
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        public Startup(IWebHostEnvironment env)
        {
            _confString = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication(x =>
            //{
            //    x.DefaultScheme = "Default";
            //    x.AddScheme<AuthHandler>(x.DefaultScheme, null); 
            //});
            services.AddCors();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<WebMappingProfile>();
                cfg.AddProfile<DataAccessMappingProfile>();
            });

            services.AddDbContext<DiaryAppDbContext>(options => options
                .UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ElecDiary API", Version = "v1" });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "StudentASP.Web.xml");
                c.IncludeXmlComments(filePath);
                c.CustomSchemaIds(type => type.ToString());
            });


            services.AddControllers();
            services.AddTransient<IStudentsRepository, StudentRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();

            services.AddTransient<IStudentsService, StudentService>();
            services.AddTransient<IGroupService, GroupService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "ElecDiary API V1");

            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(builder =>
                builder.AllowAnyOrigin());

            //app.UseAuthentication();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }
    }
}
