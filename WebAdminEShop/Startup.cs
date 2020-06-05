using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WebAdminEShop.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApplicationCore.Services;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using FluentValidation.AspNetCore;
using FluentValidation;
using WebAdminEShop.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebAdminEShop
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
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //           .AddDefaultUI()
            //           .AddEntityFrameworkStores<AppIdentityDbContext>()
            //                           .AddDefaultTokenProviders();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie();
            


            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            //services.AddIdentity<IdentityUser, IdentityRole>()

            //    .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            })
       .AddEntityFrameworkStores<ApplicationDbContext>()
       .AddDefaultTokenProviders();

            services.AddDbContext<EShopContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<ProductDTO>, ProductDTOValidation>();
            services.AddServices();
        }
       

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
    public static class ServiceProviderExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IManufacturerService,ManufacturerService>();
            services.AddTransient<IMicrrowaveService, MicrowaveService>();
            services.AddTransient<IPhoneService,PhoneService>();
            services.AddTransient<IProductService,ProductService>();
            services.AddTransient<ISpeciesService,SpeciesService>();
            services.AddTransient<IFridgeService, FridgeService>();

        }
    }
}
