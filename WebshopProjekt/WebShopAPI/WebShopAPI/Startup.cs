using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopAPI.Models;

namespace WebShopAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

       
        private string _policyName = "CorsPolicy";
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "V1" });
            });

            /*services.AddCors(options =>
            {
                options.AddPolicy("MyCorsImplementationPolicy", builder => builder.WithOrigins("*"));
            });*/

            services.AddCors(options =>
            {
                options.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddDbContext<webaruhazContext>();
            services.AddControllers();
            services.AddRazorPages();
            services.AddRouting();
            services.AddControllersWithViews();
            services.AddHttpClient();
        }
    

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();

            

            app.UseSwaggerUi3();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swaggwe/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseCors(_policyName);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapSwagger();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
