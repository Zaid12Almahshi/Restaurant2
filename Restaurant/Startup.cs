using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Data;
using Restaurant.Models;
using Restaurant.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbcontext>();
            services.AddDbContext<AppDbcontext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("SqlCon"));

            });
            services.AddScoped<IRepository<MasterCategoryMenu>, MasterCategoryMenuRepository>();
            services.AddScoped<IRepository<MasterContactUsInformation>, MasterContactUsInformationRepository>();
            services.AddScoped<IRepository<MasterItemMenu>, MasterItemMenuRepository>();
            services.AddScoped<IRepository<MasterMenu>, MasterMenuRepository>();
            services.AddScoped<IRepository<MasterOffer>, MasterOfferRepository>();
            services.AddScoped<IRepository<MasterPartner>, MasterPartnerRepository>();
            services.AddScoped<IRepository<MasterService>, MasterServiceRepository>();
            services.AddScoped<IRepository<MasterSlider>, MasterSliderRepository>();
            services.AddScoped<IRepository<MasterSocialMedium>, MasterSocialMediumRepository>();
            services.AddScoped<IRepository<MasterWorkingHour>, MasterWorkingHourRepository>();
            services.AddScoped<IRepository<SystemSetting>, SystemSettingRepository>();
            services.AddScoped<IRepository<TransactionBookTable>, TransactionBookTableRepository>();
            services.AddScoped<IRepository<TransactionContactU>, TransactionContactURepository>();
            services.AddScoped<IRepository<TransactionNewsletter>, TransactionNewsletterRepository>();
            services.AddScoped<IRepository<breadcrumb_area>, breadcrumb_areaRepository>();

            services.Configure<IdentityOptions>(x =>
            {
                x.Password.RequireNonAlphanumeric = false;
                x.Password.RequireUppercase = false;
                x.Password.RequireDigit = false;
                x.Password.RequireLowercase = false;
                x.Password.RequiredLength = 3;


            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMvc();
            //app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=index}/{id?}"
                    );

            });
        }
    }
}
