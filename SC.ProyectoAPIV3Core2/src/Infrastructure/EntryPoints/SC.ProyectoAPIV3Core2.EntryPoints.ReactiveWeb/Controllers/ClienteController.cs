using AutoMapper;
using credinet.comun.api;
using Microsoft.AspNetCore.Mvc;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static credinet.comun.negocio.RespuestaNegocio<credinet.exception.middleware.models.ResponseEntity>;
using static credinet.exception.middleware.models.ResponseEntity;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities;
using SC.ProyectoAPIV3Core2.Domain.UseCase;
using System;
using Microsoft.AspNetCore.JsonPatch;

namespace SC.ProyectoAPIV3Core2.EntryPoints.ReactiveWeb.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class ClienteController : BaseController<ClienteController>
    {
        private readonly ManageClienteUseCase manage;
        private readonly IMapper mapper;

        public ClienteController(ManageClienteUseCase manage, IMapper mapper)
        {
            this.manage = manage;
            this.mapper = mapper;
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cliente>))]
        public async Task<IActionResult> Get()
        {
            var respuestaNegocio = await manage.Findall();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }


               
        [ProducesResponseType(404)]
        [HttpGet(Name ="FindById")]
        [ProducesResponseType(200, Type = typeof(Cliente))]
        public  async Task<ActionResult<Cliente>> FindById(int id)
        {            
            var respuestaNegocio = await manage.FindById(id);
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
        public async Task<ActionResult> Post([FromBody] Cliente_dto cliente_dto)
        {
            Cliente cliente = mapper.Map<Cliente>(cliente_dto);            
            await manage.Add(cliente);
            var respuestaNegocio =  CreatedAtAction(nameof(FindById), new { id = cliente.Id }, cliente);
            //var respuestaNegocio = new CreatedAtRouteResult("GetById", new { id = cliente.Id }, cliente_tempo);
            //return respuestaNegocio;
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

       

        [ProducesResponseType(200, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        [HttpPut()]
        public async Task<ActionResult> Update([FromBody] Cliente_dto cliente_dto)
        {

            var cliente = mapper.Map<Cliente>(cliente_dto);

            var identificador = await manage.Update(cliente);
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
        public async Task<ActionResult> Delete(int id)
        {
            /*var cliente_DB = await manage.FindById(id);
            if (cliente_DB == null)
            {
                return BadRequest();
            }*/
            await manage.Delete(id);
            return NoContent();





            
        }


        /*[HttpPatch()]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Cliente_dto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            var cliente_DB = await manage.FindById(id);


            if (cliente_DB == null)
            {
                return NotFound();
            }

            //var cliente_dto = mapper.Map<Cliente_dto>(cliente_DB);
            await manage.Patch(id,patchDocument);

            patchDocument.ApplyTo(cliente_dto, ModelState);

            mapper.Map(autorDTO, autorDeLaDB);

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
