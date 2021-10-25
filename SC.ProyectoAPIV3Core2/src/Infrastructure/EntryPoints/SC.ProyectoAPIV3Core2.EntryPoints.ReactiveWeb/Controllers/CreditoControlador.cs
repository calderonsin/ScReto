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
        private readonly GestionarCreditoCasosUsos manage;
        private readonly IMapper mapper;

        public CreditoControlador(GestionarCreditoCasosUsos manage, IMapper mapper)
        {
            this.manage = manage;
            this.mapper = mapper;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet(Name = "GetCreditoById")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Credito>))]
        public async Task<IActionResult> GetCredito()
        {
            var respuestaNegocio = await manage.EncontrarTodo();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

        [ProducesResponseType(404)]
        [HttpGet(Name = "FindByCreditoId")]
        [ProducesResponseType(200, Type = typeof(Credito))]
        public async Task<ActionResult<Credito>> FindByCreditoId(int id)
        {
            var respuestaNegocio = await manage.EncontrarPorId(id);
            if (respuestaNegocio == null)
            {
                return NotFound();
            }

            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }




        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Post([FromBody] Credito_dto credito_dto)
        {
            var credito = mapper.Map<Credito>(credito_dto);
            var credito_BD = await manage.AñadirCredito(credito);
            //check if the request is valid or not
            if (credito_BD == null)
            {
                return BadRequest();
            }
            var respuestaNegocio = CreatedAtAction(nameof(FindByCreditoId), new { id = credito_BD.CreditoId }, credito_BD);
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }


    }
}
