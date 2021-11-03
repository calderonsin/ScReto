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
        /// <summary>
        /// Inicializa Un nuevo CLienteControlador<see cref="ClienteControlador"/> class.
        /// </summary>
        /// <param name="gestionar">The gestionar.</param>
        /// <param name="mappeo">The mappeo.</param>
        public ClienteControlador(GestionarClienteCasosUsos gestionar, IMapper mappeo)
        {
            this.gestionar = gestionar;
            this.mappeo = mappeo;
        }
        /// <summary>
        /// Crear cliente.
        /// </summary>
        /// <param name="cliente_dto">The cliente dto.</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Crear([FromBody] Cliente_dto cliente_dto)
        {
            Cliente cliente = mappeo.Map<Cliente>(cliente_dto);
            await gestionar.Añadir(cliente);
            var respuestaNegocio = CreatedAtAction(nameof(EncontrarClientePorId), new { id = cliente.Id }, cliente);
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

        /// <summary>
        /// muestra todos los clientes.
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Cliente>))]
        public async Task<IActionResult> EncontrarClientes()
        {
            var respuestaNegocio = await gestionar.EncontrarTodo();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }
        /// <summary>
        /// Encontra  por id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ProducesResponseType(404)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(Cliente))]
        public async Task<ActionResult<Cliente>> EncontrarClientePorId(int id)
        {
            var respuestaNegocio = await gestionar.EncontrarPorId(id);
            if (respuestaNegocio == null)
            {
                return NotFound("Cliente no encontrado");
            }

            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }
       
        /// <summary>
        /// Actualizar cliente.
        /// </summary>
        /// <param name="cliente_dto">The cliente dto.</param>
        /// <returns></returns>
        [ProducesResponseType(200, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        [HttpPut()]
        public async Task<ActionResult> Actualizar([FromBody] Cliente_dto cliente_dto)
        {

            var cliente = mappeo.Map<Cliente>(cliente_dto);

            var identificador = await gestionar.Actualizar(cliente);
            if (identificador == 0)
            {
                return BadRequest("Cliente no existe");
            }
            var respuestaNegocio = cliente;
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

        /// <summary>
        /// Borrar cliente con id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [ProducesResponseType(204, Type = typeof(Cliente))]
        [ProducesResponseType(400)]
        [HttpDelete()]
        public async Task<ActionResult> Borrar(int id)
        {
            if (id == 0)
            {
                return BadRequest("Id no valida");
            }
            int result = 0;
            result = await gestionar.Borrar(id);
            if (result == 0)
            {
                return NotFound("cliente no encontrado");
            }
            else
            {
                return Ok("Cliente actualizado");
            }
        }
    }
}
