using AutoMapper;
using credinet.comun.api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using SC.ProyectoAPIV3Core2.Domain.UseCase;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Mongo;
using SC.ProyectoAPIV3Core2.DrivenAdapters;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities;


namespace SC.ProyectoAPIV3Core2.AppServices
{
    /// <summary>
    /// ConfigurationServices
    /// </summary>
    public static class ConfigurationServices
    {
        /// <summary>
        /// AgregarServicios
        /// </summary>
        /// <param name="services"></param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AgregarServicios(this IServiceCollection services)
        {
            //service for type 'credinet.comun.api.RespuestaApiFactory'
            //services.AddScoped<DbContext, ScDbContext>();
            services.AddSingleton<IMensajesHelper, MensajesApiHelper>();
            //services.AddScoped<IClienteRepository<Cliente>, ClienteAdapter>();
            services.AddControllers();
            services.AddScoped <ScDbContext>();
            services.AddScoped<ManageTestEntityUserCase>();
            services.AddScoped<ManageClienteUseCase>();
            services.AddScoped<ManageCreditoUseCase>();
            services.AddScoped<ClienteAdapter>();
            services.AddScoped<ITestEntityRepository>(provider => new EntityAdapter(services.BuildServiceProvider().GetRequiredService<IMapper>()));
            services.AddScoped<IClienteRepository<Cliente>>(provider => new ClienteAdapter(services.BuildServiceProvider().GetRequiredService<ScDbContext>()));
            services.AddScoped<ICreditoRepository<Credito>>(provider => new CreditoAdapter(services.BuildServiceProvider().GetRequiredService<ScDbContext>()));

            //REGISTRE ACÁ SUS SERVICIOS
            return services;
        }
    }
}
