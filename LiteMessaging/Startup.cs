using Application;
using Application.Interfaces;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using LiteMessaging.CustomsAttributes;
using LiteMessaging.CustomServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace LiteMessaging
{
    public class Startup
    {
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.Filters.Add(new ResponseExceptionFilter());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LiteMessaging", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "LiteMessaging", Version = "v2" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(Environment.WebRootPath, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            services.AddApplicationLayer();
            services.AddPersistenceLayer(Configuration);

            #region CustomService
            services.AddTransient<INotificationService, NotificationService>();
            #endregion

            #region FirebaseConfig
            var rootPath = Environment.WebRootPath
                + Path.DirectorySeparatorChar.ToString()
                + "Keys"
                + Path.DirectorySeparatorChar.ToString()
                + "FB"
                + Path.DirectorySeparatorChar.ToString()
                + "litemessaging-firebase-adminsdk-wvxlw-5210105a9e.json";
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(rootPath)
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiteMessaging v1"));
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiteMessaging v1"));
            }

            app.UseSwagger();
            app.UseApiVersioning();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiteMessaging v1");
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LiteMessaging v1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
