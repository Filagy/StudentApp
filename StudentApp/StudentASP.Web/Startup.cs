using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentASP.DataAccess.MSSQL;
using StudentASP.DataAccess.MSSQL.Repository;
using StudentASP.Domain.Interfaces;

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
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<WebMappingProfile>();
                cfg.AddProfile<DataAccessMappingProfile>();
            });

            services.AddDbContext<StudentAppDbContext>(options => options
                .UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

            services.AddMvc();
            services.AddControllersWithViews();
            services.AddTransient<IStudentRepository, StudentRepository>();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //app.UseMvcWithDefaultRoute();


            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<StudentAppDbContext>();

                DbObjects.Initial(context);
            }

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Students}/{action=GetAllStudents}");

            });
        }
    }
}
