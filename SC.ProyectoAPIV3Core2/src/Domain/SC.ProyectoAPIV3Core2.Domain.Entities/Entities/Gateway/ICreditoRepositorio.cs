using System.Collections.Generic;
using System.Threading.Tasks;


namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway
{
    public interface ICreditoRepositorio<T>
    {
        Task<List<T>> EncontrarTodo();
        Task<T> Add(T credito);
        Task<int> Update(T credito);
        Task<T> EncontrarPorId(int creditoId);
        Task Delete(int id);
    }
}
