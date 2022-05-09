using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PerfectSite.Data.MongoDb;
using PerfectSite.Models;
using System.Globalization;

namespace PerfectSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<MongoOptions>(Configuration.GetSection("MongoDB"));
            services.AddSingleton<MongoService>();

            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = null;

                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<ApplicationContext>()
            .AddTokenProvider<DataProtectorTokenProvider<User>>(TokenOptions.DefaultProvider);

            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthorization();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "store_area",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                name: "account_area",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}