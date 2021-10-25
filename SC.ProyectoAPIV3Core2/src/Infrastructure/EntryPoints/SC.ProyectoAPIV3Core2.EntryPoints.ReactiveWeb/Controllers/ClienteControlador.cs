using AutoMapper;
using credinet.comun.api;
using Microsoft.AspNetCore.Mvc;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static credinet.comun.negocio.RespuestaNegocio<credinet.exception.middleware.models.ResponseEntity>;
using static credinet.exception.middleware.models.ResponseEntity;
using SC.ProyectoAPIV3Core2.Domain.UseCase;

namespace SC.ProyectoAPIV3Core2.EntryPoints.ReactiveWeb.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class ClienteControlador : BaseController<ClienteControlador>
    {
        private readonly GestionarClienteCasosUsos gestionar;
        private readonly IMapper mappeo;

        public ClienteControlador(GestionarClienteCasosUsos gestionar, IMapper mappeo)
        {
            this.gestionar = gestionar;
            this.mappeo = mappeo;
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cliente>))]
        public async Task<IActionResult> Get()
        {
            var respuestaNegocio = await gestionar.EncontrarTodo();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }


               
        [ProducesResponseType(404)]
        [HttpGet(Name ="EncontrarPorId")]
        [ProducesResponseType(200, Type = typeof(Cliente))]
        public  async Task<ActionResult<Cliente>> EncontrarPorId(int id)
        {            
            var respuestaNegocio = await gestionar.EncontrarPorId(id);
            if (respuestaNegocio == null )
                {
                return NotFound();
            }
            
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

        /// <summary>
        /// Create Cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Crear([FromBody] Cliente_dto cliente_dto)
        {
            Cliente cliente = mappeo.Map<Cliente>(cliente_dto);            
            await gestionar.Añadir(cliente);
            var respuestaNegocio =  CreatedAtAction(nameof(EncontrarPorId), new { id = cliente.Id }, cliente);
            //var respuestaNegocio = new CreatedAtRouteResult("GetById", new { id = cliente.Id }, cliente_tempo);
            //return respuestaNegocio;
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

       

        [ProducesResponseType(200, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        [HttpPut()]
        public async Task<ActionResult> Actualizar([FromBody] Cliente_dto cliente_dto)
        {

            var cliente = mappeo.Map<Cliente>(cliente_dto);

            var identificador = await gestionar.Actualizar(cliente);
            if (identificador == 0)
            {
                return BadRequest();
            }
            var respuestaNegocio = cliente;
                    
            //return NoContent();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

     
        [ProducesResponseType(204, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        [HttpDelete()]
        public async Task<ActionResult> Borrar(int id)
        {
            if (id == 0) 
            {
                return BadRequest();
            }
            int result = 0;
            result = await gestionar.Borrar(id);
            if (result == 0)
            {
                return NotFound();
            }
            else 
            {
                return Ok();
            }





            
        }


        /*[HttpPatch()]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Cliente_dto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var cliente_DB = await gestionar.EncontrarPorId(id);


            if (cliente_DB == null)
            {
                return NotFound();
            }

            //var cliente_dto = mappeo.Map<Cliente_dto>(cliente_DB);
            await gestionar.Patch(id,patchDocument);

            patchDocument.ApplyTo(cliente_dto, ModelState);

            mappeo.Map(autorDTO, autorDeLaDB);

            var isValid = TryValidateModel(autorDeLaDB);

            if (!isValid)
            {
                return BadRequest(ModelState);
            }

            await context.SaveChangesAsync();

            return NoContent();

        }*/


    }
}
