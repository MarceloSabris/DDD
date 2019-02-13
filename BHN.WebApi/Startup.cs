using BHN.Infrastructure.DI;
using BHN.WebApi.DI;
using Enterprise.Framework.Collections;
using Enterprise.Framework.WebApi.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace BHN.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceCollection Services { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.Services = services;
            services.AddMvc();
            services.AddOptions();            
            services.AddSingleton(typeof(IControllerActivator), typeof(ControllerResolver));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.AddMvc();

            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "BHN",
                    Version = "v1",
                    Description = "Um microserviço para a gestão de BHN.",
                    Contact = new Contact
                    {
                        Name = "Arquitetura",
                        Email = "ti.arquitetura@viavarejo.com.br"
                    }
                });

                c.CustomSchemaIds((type) => type.FullName);

                var xmlWebApiFile = Path.Combine(AppContext.BaseDirectory, $"BHN.WebApi.xml");
                if (File.Exists(xmlWebApiFile))
                {
                    c.IncludeXmlComments(xmlWebApiFile);
                }

                var xmlApplicationFile = Path.Combine(AppContext.BaseDirectory, "BHN.Application.xml");
                if (File.Exists(xmlApplicationFile))
                {
                    c.IncludeXmlComments(xmlApplicationFile);
                }

                c.CustomSchemaIds((Type currentClass) =>
                {
                    var returnedValue = currentClass.Name;

                    if (returnedValue.EndsWith("Dto", StringComparison.InvariantCultureIgnoreCase))
                    {
                        returnedValue = returnedValue.Replace("Dto", string.Empty, StringComparison.InvariantCultureIgnoreCase);
                    }

                    if (returnedValue.EndsWith("Request", StringComparison.InvariantCultureIgnoreCase))
                    {
                        returnedValue = returnedValue.Replace("Request", "PayloadEntrada", StringComparison.InvariantCultureIgnoreCase);
                    }

                    if (returnedValue.EndsWith("Response", StringComparison.InvariantCultureIgnoreCase))
                    {
                        returnedValue = returnedValue.Replace("Response", "PayloadSaida", StringComparison.InvariantCultureIgnoreCase);
                    }
                    return returnedValue;
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var appSettings = new ParsableNameValueCollection(Configuration.GetSection("AppSettings"));
            new Bootstrap(appSettings).Initialize(Services);

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseCorrelationId();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Orquestrador");
                options.DisplayRequestDuration();
            });

            app.UseCors("AllowAll");
            app.UseMvc();
        }
    }
}
