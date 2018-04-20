using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Castle.Logging.Log4Net;
using Castle.Facilities.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MyDocumentManageNetCore.Web
{
    public class Startup
    {
        private const string _defaultCorsPolicyName = "localhost";
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // MVC
            services.AddMvc(
                options => options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName))
            ).AddJsonOptions(
                op => op.SerializerSettings.ContractResolver = new DefaultContractResolver()
                );
            var urls = Configuration.GetSection("App").GetValue<string>("CorsOrigins");
            services.AddCors(options =>
           options.AddPolicy("AllowSameDomain",
           builder => builder.WithOrigins(urls).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials())
           );
            // Swagger - Enable this line and the related lines in Configure method to enable swagger UI
            //services.AddSwaggerGen(options =>
            //{
            //    options.SwaggerDoc("v1", new Info { Title = "GeneDocument API", Version = "v1" });
            //    options.DocInclusionPredicate((docName, description) => true);

            //    // Define the BearerAuth scheme that's in use
            //    options.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
            //    {
            //        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            //        Name = "Authorization",
            //        In = "header",
            //        Type = "apiKey"
            //    });
            //    // Assign scope requirements to operations based on AuthorizeAttribute
            //    options.OperationFilter<SecurityRequirementsOperationFilter>();
            //});
            // Configure Abp and Dependency Injection
            return services.AddAbp<MyDocumentManageNetCoreWebModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }
       

        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();

        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAbp(); // Initializes ABP framework.

            //app.UseCors(_defaultCorsPolicyName); // Enable CORS!

            //app.UseStaticFiles();

            //app.UseAuthentication();

            //app.UseAbpRequestLocalization();
            //app.UseAbp();
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //app.UseSignalR(routes =>
            //{
            //    routes.MapHub<AbpCommonHub>("/signalr");
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Values}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Values}/{action=Index}/{id?}");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint
            //app.UseSwagger();
            //// Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            //app.UseSwaggerUI(options =>
            //{
            //    options.InjectOnCompleteJavaScript("/swagger/ui/abp.js");
            //    options.InjectOnCompleteJavaScript("/swagger/ui/on-complete.js");
            //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "GeneDocument API V1");
            //}); // URL: /swagger
        }
    }
}
