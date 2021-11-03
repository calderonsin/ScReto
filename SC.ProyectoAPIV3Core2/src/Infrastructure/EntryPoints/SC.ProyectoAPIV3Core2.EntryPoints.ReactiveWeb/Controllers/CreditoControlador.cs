using AutoMapper;
using credinet.comun.api;
using Microsoft.AspNetCore.Mvc;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.UseCase;
using System.Collections.Generic;
using System.Threading.Tasks;
using static credinet.comun.negocio.RespuestaNegocio<credinet.exception.middleware.models.ResponseEntity>;
using static credinet.exception.middleware.models.ResponseEntity;
namespace SC.ProyectoAPIV3Core2.EntryPoints.ReactiveWeb.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class CreditoControlador : BaseController<CreditoControlador>
    {
        private readonly GestionarCreditoCasosUsos Gestionar;
        private readonly IMapper mapeo;
        /// <summary>
        /// Inicializa una nueva instancia de <see cref="CreditoControlador"/> class.
        /// </summary>
        /// <param name="gestionar">The gestionar.</param>
        /// <param name="mapeo">The mapeo.</param>
        public CreditoControlador(GestionarCreditoCasosUsos gestionar, IMapper mapeo)
        {
            this.Gestionar = gestionar;
            this.mapeo = mapeo;
        }
        /// <summary>
        /// Encontrar todos los creditos.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Credito>))]
        public async Task<IActionResult> EncontrarCreditos()
        {
            var respuestaNegocio = await Gestionar.EncontrarTodo();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }
        /// <summary>
        /// Encontrar credito por id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ProducesResponseType(404)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(Credito))]
        public async Task<ActionResult<Credito>> EncontrarCreditoPorId(int id)
        {
            var respuestaNegocio = await Gestionar.EncontrarPorId(id);
            if (respuestaNegocio == null)
            {
                return NotFound("credito no encontrado");
            }
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

        /// <summary>Crears the specified credito dto.</summary>
        /// <param name="credito_dto">The credito dto.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Crear([FromBody] Credito_dto credito_dto)
        {
            Credito credito = mapeo.Map<Credito>(credito_dto);
            await Gestionar.AñadirCredito(credito);
            //check if the request is valid or not
            var respuestaNegocio = CreatedAtAction(nameof(EncontrarCreditoPorId), new { id = credito.CreditoId }, credito);
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }


    }
}
