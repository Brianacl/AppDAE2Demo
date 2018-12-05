using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppDAE2Demo
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                  name: "areaGeneralList",
                  template: "{area:exists}/{controller=CatEdificios}/{action=Edificioslist}/{id?}");

                routes.MapRoute(
                  name: "areaGeneralDetalle",
                  template: "{area:exists}/{controller=CatEdificios}/{action=Edificiosdetalle}/{id?}");

                routes.MapRoute(
                 name: "areaGeneralEliminar",
                 template: "{area:exists}/{controller=CatEdificios}/{action=Edificiodelete}/{id?}");

                routes.MapRoute(
                 name: "areaGeneralAgregar",
                 template: "{area:exists}/{controller=CatEdificios}/{action=Edificioadd}/{id?}");

                routes.MapRoute(
                 name: "areaGeneralEditar",
                 template: "{area:exists}/{controller=CatEdificios}/{action=Edificioedit}/{id?}");


                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
