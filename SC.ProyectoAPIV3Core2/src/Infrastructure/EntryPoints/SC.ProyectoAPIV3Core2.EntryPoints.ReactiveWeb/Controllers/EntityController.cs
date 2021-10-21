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
    /// <summary>
    /// EntityController
    /// </summary>
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/[action]")]
    public class EntityController : BaseController<EntityController>
    {
        private readonly ManageTestEntityUserCase testNegocio;

        /// <summary>
        /// Build
        /// </summary>
        /// <param name="testNegocio"></param>
        public EntityController(ManageTestEntityUserCase testNegocio)
        {
            this.testNegocio = testNegocio;
        }

        /// <summary>
        /// Obtiene todos los objetos de tipo <see cref="Entity"/>
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Retorna la lista</response>
        /// <response code="400">Si existe algun problema al consultar</response>
        /// <response code="406">Si no se envia el ambiente correcto</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(406)]
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public async Task<IActionResult> Get()
        {
            var respuestaNegocio = await testNegocio.GetAllUsers();
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Entity>))]
        public async Task<IActionResult> Create([FromBody] Entity entity)
        {
            var respuestaNegocio = await testNegocio.GetAllUsers(entity);
            return await ProcesarResultado(Exito(Build(Request.Path.Value, 0, "", "co", respuestaNegocio)));
        }
    }
}