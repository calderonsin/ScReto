using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IClienteRepositorio<T>
    {
        /// <summary>
        /// Añadir cliente.
        /// </summary>
        /// <param name="cliente">The cliente.</param>
        /// <returns></returns>
        Task<T> Añadir(T cliente);
        /// <summary>
        /// Actualizars  cliente.
        /// </summary>
        /// <param name="cliente">The cliente.</param>
        /// <returns></returns>
        Task<int> Actualizar(T cliente);
        /// <summary>
        /// Encontrar  por id.
        /// </summary>
        /// <param name="clienteId">The cliente identifier.</param>
        /// <returns></returns>
        Task<T> EncontrarPorId(int clienteId);
        /// <summary>
        /// Mostrar  todo.
        /// </summary>
        /// <returns></returns>
        Task<List<T>> MostrarTodo();
        /// <summary>
        /// Borrars the clienter.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<int> Borrar(int id);
    }
}
