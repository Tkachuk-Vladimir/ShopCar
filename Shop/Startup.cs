﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.Data.mocks;
using Microsoft.Extensions.Configuration;
using Shop.Data;
using Microsoft.EntityFrameworkCore;
using Shop.Data.Repository;

namespace Shop
{
    public class Startup
    {
        private IConfigurationRoot _confString;

        
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv)
        {
          _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrder, OrdersRepository>();

            services.AddDbContext<AppDBContent>(options => options.UseSqlite(_confString.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            //services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseCors();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(name: "categoryFilter", template: "Car/action/{category?}", defaults: new {Controller = "Car", action ="List"});
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           /* app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}");
            });
           */

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DbObjects.Initial(content);
            }

        }
    }
}
