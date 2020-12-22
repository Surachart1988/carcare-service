using Csp.DAL.Infrastructure;
using Csp.DAL.Models;
using Csp.DAL.UnitOfWork;
using Csp.Services.Interfaces;
using Csp.Services.Services;
using AutoMapper;
using Csp.Api.Helper;
using Csp.Api.Middleware;
using Csp.Logger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Csp.Api
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
            services.AddControllersWithViews();
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Csp API", Description = "Csp API ProconsultPlus", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
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
                     new string[] {}             }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // added Redis distributed cache
            services.AddStackExchangeRedisCache(options => options.Configuration = this.Configuration.GetConnectionString("Redis"));
            services.AddSingleton<ICacheService, CacheService>();

            // Validate Token
            services.AddTokenAuthentication(Configuration);

            //services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddScoped<IConnectionFactory, ConnectionFactory>();
            services.AddScoped<IJwtService, JwtService>();

            // Create GenericRepository of User for 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IContactTypesService, ContactTypesService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IMasterDataService, MasterDataService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IReportServiceRequestService, ReportServiceRequestService>();
            services.AddScoped<IReportDailySalesService, ReportDailySalesService>();

            services.AddAutoMapper(typeof(MappingProfile));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                //c.InjectStylesheet("/swagger-ui/custom.css");
#if DEBUG

                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Csp API");
#else
                c.SwaggerEndpoint("v1/swagger.json", "Csp API");
#endif

            });
            app.UseRouting();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
