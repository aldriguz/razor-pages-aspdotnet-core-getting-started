using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WiredBrainCoffee.Services;

namespace WiredBrainCoffee
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
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/index", "home");
                options.Conventions.AddPageRoute("/index", "wired");
            });

            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("promo", typeof(PromoConstraint));
            });

            services.AddScoped<IMenuService, MenuService>();
            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.Contains("alive"))
                {
                    UnicodeEncoding uniencoding = new UnicodeEncoding();
                    byte[] outputMsg = uniencoding.GetBytes("The app is alive");
                    //research how to print on screen instead of download file
                    await context.Response.Body.WriteAsync(outputMsg, 0, outputMsg.Length);
                }
                else
                {
                    Debug.WriteLine("Before Razor pages");
                    await next.Invoke();
                    Debug.WriteLine("After Razor pages");
                }
            });
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
