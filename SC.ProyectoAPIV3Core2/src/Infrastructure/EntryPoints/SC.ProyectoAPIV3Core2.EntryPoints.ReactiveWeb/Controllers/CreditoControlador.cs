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

        public CreditoControlador(GestionarCreditoCasosUsos gestionar, IMapper mapeo)
        {
            this.Gestionar = gestionar;
            this.mapeo = mapeo;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet(Name = "GetCreditoById")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Credito>))]
        public async Task<IActionResult> ObtenerCredito()
        {
            var respuestaNegocio = await Gestionar.EncontrarTodo();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

        [ProducesResponseType(404)]
        [HttpGet(Name = "EncontrarPorId")]
        [ProducesResponseType(200, Type = typeof(Credito))]
        public async Task<ActionResult<Credito>> EncontrarPorId(int id)
        {
            var respuestaNegocio = await Gestionar.EncontrarPorId(id);
            if (respuestaNegocio == null)
            {
                return NotFound();
            }

            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }




        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Crear([FromBody] Credito_dto credito_dto)
        {
            var credito = mapeo.Map<Credito>(credito_dto);
            var credito_BD = await Gestionar.AñadirCredito(credito);
            //check if the request is valid or not
            if (credito_BD == null)
            {
                return BadRequest();
            }
            var respuestaNegocio = CreatedAtAction(nameof(EncontrarPorId), new { id = credito_BD.CreditoId }, credito_BD);
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }


    }
}
