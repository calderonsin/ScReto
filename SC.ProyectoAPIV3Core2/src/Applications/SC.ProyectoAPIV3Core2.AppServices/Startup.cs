using AutoMapper;
using AutoMapper.Data;
using credinet.comun.api;
using credinet.comun.api.Swagger.Extensions;
using credinet.exception.middleware;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using SC.AdministradorLlaves;

namespace SC.ProyectoAPIV3Core2.AppServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddMvc(option => option.EnableEndpointRouting = false).AddNewtonsoftJson().AddFluentValidation();
            services.AddCors(options =>
            {
                options.AddPolicy("cors", b => b.AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            });
            services.AddControllers();

            services.AddRespuestaApiFactory();
            services.AddVersionedApiExplorer();
            //var mongoConnString = GetConnection(appSettings.CreditNetstoreDbLogin);
            //services.AddSingleton<IContext>(provider => new Context(mongoConnString, $"{appSettings.DataBaseCrediNetRequest}_{country}"));

            services.AddAutoMapper(v =>
            {
                v.AddDataReaderMapping();
            });
            Mapper.Initialize(cfg => { });

            services.AgregarServicios();
            services.HabilitarVesionamiento();
            services.ConfigurarSwaggerConVersiones(Environment, PlatformServices.Default.Application.ApplicationBasePath, new string[] { "SC.ProyectoAPIV3Core2.AppServices.xml" });

            //this configuration take the extensions .xml for defect
            //services.ConfigurarSwaggerConVersiones(Environment, PlatformServices.Default.Application.ApplicationBasePath);
        }

        public string GetConnection(string urlKeyConexion)
        {
            var admLlaves = new ScAdministradorLlaves(Configuration);
            return admLlaves.ObtenerLlave(urlKeyConexion).GetAwaiter().GetResult();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            app.UseCors("cors");
            app.UseStaticFiles(); // For the wwwroot folder

            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger((c) =>
                {
                    c.PreSerializeFilters.Add((swaggerDoc, httpRequest) => { swaggerDoc.Info.Description = httpRequest.Host.Value; });
                });
                app.UseSwaggerUI(
                options =>
                {
                    // build a swagger endpoint for each discovered API version
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint($"../swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                    }
                    options.InjectStylesheet($"../swagger.{env.EnvironmentName}.css");
                });
            }
            else
            {
                app.UseHsts();
            }
            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseAmbienteHeaderMiddleware();
            app.UseOrigenHeaderMiddleware();
            app.UseMvc();
        }
    }
}