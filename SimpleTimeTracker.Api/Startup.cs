using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SimpleTimeTracker.Api
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // override the unauthorized api hits from a redirect to a 401
            //services.AddIdentity<User, Role>(identityOptions =>
            //{
            //    identityOptions.Cookies.ApplicationCookie.Events =
            //        new CookieAuthenticationEvents
            //        {
            //            OnRedirectToLogin = context =>
            //            {
            //                if (context.Request.Path.StartsWithSegments("/api") &&
            //            context.Response.StatusCode == (int)HttpStatusCode.OK)
            //                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //                else
            //                    context.Response.Redirect(context.RedirectUri);

            //                return Task.CompletedTask;
            //            }
            //        };
            //});

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            ConfigureAuth(app);

            app.UseMvc();
        }
    }
}
