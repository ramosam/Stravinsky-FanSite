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

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration["Data:Stravinsky:MSSQLConnection"]));
            }
            else
            {
                services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlite(Configuration["Data:Stravinsky:SQLiteConnection"]));
            }
                //services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(
                //    Configuration["Data:SportStoreIdentity:ConnectionString"]));

                //services.AddDbContext<AppIdentityDbContext>(options =>
                //options.UseSqlite(Configuration["Data:Stravinsky:SQLiteConnection"]));

            services.AddTransient<IRepository, Repository>();





            services.AddIdentity<AppUser,IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                // opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();



            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppIdentityDbContext context)
        {
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

            app.UseRouting();

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
