using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.UseCase
{
    /// <summary>
    /// Caso de uso para gestionar Cliente
    /// </summary>
    public class GestionarClienteCasosUsos
    {
        private readonly IClienteRepositorio<Cliente> clienterepositorio;

        /// <summary>
        /// inicializa una nueva instancia de <see cref="GestionarClienteCasosUsos"/> class.
        /// </summary>
        /// <param name="cLienterepositorio">The c lienterepositorio.</param>
        public GestionarClienteCasosUsos(IClienteRepositorio<Cliente> cLienterepositorio)
        {
            this.clienterepositorio = cLienterepositorio;
        }

        /// <summary>
        /// Encontrars  todo.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Cliente>> EncontrarTodo()
        {

            return await clienterepositorio.MostrarTodo();

        }

        /// <summary>
        /// Encontrars  por identificador.
        /// </summary>
        /// <param name="ClienteId">The cliente identifier.</param>
        /// <returns></returns>
        public async Task<Cliente> EncontrarPorId(int ClienteId)
        {
            return await clienterepositorio.EncontrarPorId(ClienteId);


        }

        /// <summary>
        /// Añadir el cliente.
        /// </summary>
        /// <param name="cliente">The cliente.</param>
        /// <returns></returns>
        public async Task<Cliente> Añadir(Cliente cliente)
        {
            return await clienterepositorio.Añadir(cliente);


        }

        /// <summary>
        /// Actualizars el cliente.
        /// </summary>
        /// <param name="cliente">The cliente.</param>
        /// <returns></returns>
        public async Task<int> Actualizar(Cliente cliente)
        {
            return await clienterepositorio.Actualizar(cliente);


        }

        /// <summary>
        /// Borrar cliente.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> Borrar(int id)
        {
            return await clienterepositorio.Borrar(id);


        }
    }
}
