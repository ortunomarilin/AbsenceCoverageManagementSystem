using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbsenceCoverageMS.Models.DataLayer;
using AbsenceCoverageMS.Models.DomainModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AbsenceCoverageMS
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }



        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddMemoryCache();
            services.AddSession();

            services.AddControllersWithViews().AddNewtonsoftJson(); ; 

            services.AddRazorPages().AddRazorRuntimeCompilation();

            services.AddDbContext<AbsenceManagementContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("AbsenceManagementContext")));

            //To facilitate Testing. 
            services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AbsenceManagementContext>()
              .AddDefaultTokenProviders();
        }
    



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {



                // route for Admin area
                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");





                // route for date range, filtering, and sorting 
                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{controller}/{action}/fromdate/{fromdate}/todate/{todate}/filterby/{absencetype}/{duration}/{status}/sortby/{sortby}-{sortdirection}/page-{pagenumber}/pagesize-{pagesize}");



                // route for filtering and sorting 
                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{controller}/{action}/filterby/{absencetype}/{duration}/{status}/sortby/{sortby}-{sortdirection}/page-{pagenumber}/pagesize-{pagesize}");





                //Default Route
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
