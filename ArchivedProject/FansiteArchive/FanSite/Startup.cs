using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FanSite.Repositories;
using Microsoft.AspNetCore.Identity;
using FanSite.Models;

namespace FanSite
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
            services.AddMvc();
            // For Mac OS with SQLite
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlite(
                    Configuration["Data:FanSite:SQLiteConnection"]));

            /*   // Configure EF for Windows with SQL Server
             services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                 Configuration["Data:GoodBookNook:ConnectionString"]));
                 // For Linux with MariaDB
             services.AddDbContext<ApplicationDbContext>(
                 options => options.UseMySql(
                     Configuration.GetConnectionString("Data:GoodBookNook:MySqlConnection")));
             */

            services.AddTransient<IRepository, Repository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddIdentity<AppUser, IdentityRole>(
                opts =>
            {
                opts.User.RequireUniqueEmail = true;
                // opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }
            ).AddEntityFrameworkStores<AppDbContext>()
                       .AddDefaultTokenProviders();
            

            //services.AddMvc();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext context)
        {
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

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            

            //SeedData.Seed(context);
        }
    }
}
