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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WebshopAPI.Authorization;
using WebshopAPI.DB;
using WebshopAPI.Helpers;
using WebshopAPI.Repositories;
using WebshopAPI.Services;

namespace WebshopAPI
{
    public class Startup
    {
        private readonly string CORSRules = "_CORSRules";
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(name: CORSRules,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions
                      .PropertyNamingPolicy = null;
                    options.JsonSerializerOptions
                    .Converters.Add(new JsonStringEnumConverter());
                });

            //Opsætning af vores SQL server.
            services.AddDbContext<WebshopContext>(
               o => o.UseSqlServer(_configuration.GetConnectionString("Default")));

            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));
            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepo, UserRepo>();

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepo, ItemRepo>();

            services.AddScoped<IOrdersRepo, OrdersRepo>();
            services.AddScoped<IOrdersService, OrdersService>();

            services.AddScoped<ISubRepo, SubRepo>();
            services.AddScoped<ISubService, SubService>();

            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<ICategoryService, CategoryService>();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebshopAPI", Version = "v1" }); c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }

                    }
                });
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

            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
