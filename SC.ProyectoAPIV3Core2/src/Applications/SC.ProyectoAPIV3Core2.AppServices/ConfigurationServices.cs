using AutoMapper;
using credinet.comun.api;
using Microsoft.Extensions.DependencyInjection;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using SC.ProyectoAPIV3Core2.Domain.UseCase;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Mongo;
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
            services.AddScoped <ScDbContexto>();
            services.AddScoped<ManageTestEntityUserCase>();
            services.AddScoped<GestionarClienteCasosUsos>();
            services.AddScoped<GestionarCreditoCasosUsos>();
            services.AddScoped<ClienteAdaptador>();
            services.AddScoped<ITestEntityRepositorio>(provider => new EntityAdapter(services.BuildServiceProvider().GetRequiredService<IMapper>()));
            services.AddScoped<IClienteRepositorio<Cliente>>(provider => new ClienteAdaptador(services.BuildServiceProvider().GetRequiredService<ScDbContexto>()));
            services.AddScoped<ICreditoRepositorio<Credito>>(provider => new CreditoAdaptador(services.BuildServiceProvider().GetRequiredService<ScDbContexto>()));

            //REGISTRE ACÁ SUS SERVICIOS
            return services;
        }
    }
}
