using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stravinsky.Models;
using Stravinsky.Infrastructure;
using Stravinsky.Repositories;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Stravinsky
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

            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //{
            //    services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseSqlServer(Configuration["Data:Stravinsky:MSSQLConnection"]));
            //}
            //else
            //{
            //    services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseSqlite(Configuration["Data:Stravinsky:SQLiteConnection"]));
            //}

            services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlite(Configuration["Data:Stravinsky:SQLiteConnection"]));


            services.AddTransient<IRepository, Repository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });



            services.AddIdentity<AppUser,IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();


            services.AddResponseCaching();
            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppIdentityDbContext context)
        {
            // Addressing X-Content-Type-Options, X-Frame-Options
            app.Use(async (ctx, next) =>
            {
                ctx.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                ctx.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                ctx.Response.Headers.Add("X-XSS-Protection", "1");
                ctx.Response.Headers.Add("Cache-Control", "must-revalidate, no-cache, no-store");
                ctx.Response.Headers.Add("Pragma", "no-cache");
                ctx.Response.Headers.Append("Expires", "0");
                ctx.Response.GetTypedHeaders().CacheControl =
                    new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                    {
                        Private = false,
                        MaxAge = TimeSpan.FromSeconds(10),
                        NoStore = true,
                        NoCache = true,
                        MustRevalidate = true,
                    };
                await next();
            });




            app.UseStatusCodePages();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseResponseCaching();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();


            SeedData.Seed(context);

        }
    }
}
