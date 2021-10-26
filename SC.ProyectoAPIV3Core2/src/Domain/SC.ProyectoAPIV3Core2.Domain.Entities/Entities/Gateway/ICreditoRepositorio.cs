using System.Collections.Generic;
using System.Threading.Tasks;


namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICreditoRepositorio<T>
    {
        /// <summary>
        /// Encontrars todo.
        /// </summary>
        /// <returns></returns>
        Task<List<T>> EncontrarTodo();
        /// <summary>
        /// Crea un credito.
        /// </summary>
        /// <param name="credito">The credito.</param>
        /// <returns></returns>
        Task<T> Añadir(T credito);
        /// <summary>
        /// Actualizar credito.
        /// </summary>
        /// <param name="credito">The credito.</param>
        /// <returns></returns>
        Task<int> Actualizar(T credito);
        /// <summary>
        /// Encuentro un  credito con la id creditoID.
        /// </summary>
        /// <param name="creditoId">The credito identifier.</param>
        /// <returns></returns>
        Task<T> EncontrarPorId(int creditoId);
        /// <summary>
        /// Borrar credito.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Borrar(int id);
    }
}
