using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Perspective.Extensions;

namespace Perspective
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        private IConfiguration Configuration { get; }

        private IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            services.AddHttpContextAccessor();
            services.AddHttpClient();

            services.AddBlazoredLocalStorage(config => config.JsonSerializerOptions.WriteIndented = true);

            services.AddAuthentication(options => 
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.RequireAuthenticatedSignIn = true;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => 
            { 
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/denied";
                options.LogoutPath = "/logout";
            });

            string connectionStrKey = Environment.IsDevelopment() ? "DevelopmentDB" : "ProductionDB";
            services.AddMSSqlStorage(Configuration.GetConnectionString(connectionStrKey));

            services.AddPasswordHasher();

            services.AddUserManager();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles(); 
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
