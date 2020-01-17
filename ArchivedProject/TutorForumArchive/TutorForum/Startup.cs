using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TutorForum.Models;
using TutorForum.Repositories;

namespace TutorForum
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc();

            // Add services to inject dependency
            services.AddTransient<IRepository, ForumQuestionRepository>();
            // For Mac OS with SQLite
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlite(
                    Configuration["Data:TutorForum:SQLiteConnection"]));
<<<<<<< Updated upstream
=======
            services.AddIdentity<Member, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
                       .AddDefaultTokenProviders();
            // Adding for Tutor identity
         //   services.AddIdentity<Tutor, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
         //              .AddDefaultTokenProviders();
>>>>>>> Stashed changes

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext context)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
<<<<<<< Updated upstream
            app.UseCookiePolicy();

            app.UseMvc(routes =>
=======
            app.UseCookiePolicy();



            app.UseRouting();
            app.UseEndpoints(endpoints =>
>>>>>>> Stashed changes
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseAuthentication();
            // Create or update the database and apply migrations.
          //  context.Database.Migrate();

            SeedData.Seed(context);

        }
    }
}
