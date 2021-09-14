using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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
using WebshopAPI.DB;
using WebshopAPI.Repositories;
using WebshopAPI.Services;

namespace WebshopAPI
{
    public class Startup
    {
        private readonly string CORSRules = "_CORSRules";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(name: CORSRules,
                    builder => {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
            
            services.AddControllers();

            //Ops�tning af vores SQL server.
            services.AddDbContext<WebshopContext>(
               o => o.UseSqlServer(Configuration.GetConnectionString("Default")));

            //DI -> UserService
            services.AddScoped<IUserService, UserService>();
            //DI -> UserRepo
            services.AddScoped<IUserRepo, UserRepo>();

            //DI -> ItemService
            services.AddScoped<IItemService, ItemService>();
            //DI -> ItemRepo
            services.AddScoped<IItemRepo, ItemRepo>();






            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebshopAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebshopAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(CORSRules);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
