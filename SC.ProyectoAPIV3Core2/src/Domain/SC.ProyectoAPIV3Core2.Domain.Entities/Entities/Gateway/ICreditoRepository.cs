using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway
{
    public interface ICreditoRepository<T>
    {
        Task<List<T>> FindAll();
        Task<T> Add(T credito);
        Task<int> Update(T credito);
        Task<T> FindById(int creditoId);
        Task Delete(int id);
    }
}
