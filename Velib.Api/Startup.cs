using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Net.Http;
using Velib.Api.Configuration;
using Velib.Core.Services;
using AutoMapper;
using System.IO;
using System.Reflection;

namespace Velib.Api
{
    public class Startup
    {
        private string MyAllowSpecificOrigins = "AllowClientAppOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Velib.Api",
                    Description = "Velib Web API",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "El Moumni Ahmed",
                        Email = "elmoumniahmed@gmail.com",
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                setupAction.IncludeXmlComments(xmlPath);

            });

            var options = new AppSetting();
            services.Configure<AppSetting>(Configuration.GetSection("VelibApi"));

            services.AddSingleton(options);

            services.AddTransient<IVelibService>((sp) =>
            {
                var options = sp.GetService<IOptions<AppSetting>>().Value;

                var serviceClient = new HttpClient
                {
                    BaseAddress = new Uri(options.VelibBaseUrl)
                };
                return new VelibService(serviceClient,options.SearchEndPoint,options.DataSetKeyEndPoint,options.DataSetValueEndPoint);
            });

            services.AddAutoMapper();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials();
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

                app.UseSwaggerUI(setupAction =>
                {

                    setupAction.InjectStylesheet("/Assets/custom-ui.css");
                    setupAction.IndexStream = ()
                            => GetType().Assembly
                            .GetManifestResourceStream(GetType().Namespace + ".EmbeddedAssets.Index.html");

                    setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "Velib.Api v1");

                    setupAction.DefaultModelExpandDepth(2);
                    setupAction.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                    setupAction.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                    setupAction.EnableDeepLinking();
                    setupAction.DisplayOperationId();
                });
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
