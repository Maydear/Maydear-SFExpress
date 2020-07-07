using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maydear.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SFExpressAspNetCoreSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMaydearMvc();
            services.AddMaydearRedisCache(Configuration);
            services.AddSfExpressService(Configuration);
        }

        /// <summary>
        /// 
        /// </summary>
        private readonly string corsPolicyName = "openAllowDomain";

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(corsPolicyName);
            app.UseMaydearMvc();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "default",
                  template: "{controller=Ping}/{action=Index}/{returnUrl?}"
                );
            });
        }
    }
}
