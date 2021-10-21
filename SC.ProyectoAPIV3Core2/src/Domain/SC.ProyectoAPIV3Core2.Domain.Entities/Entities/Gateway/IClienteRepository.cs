using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway
{
    public interface IClienteRepository<T>
    {
        Task<T> Add(T cliente);
        Task<int> Update(T cliente);
        Task<T> FindById(int clienteId);

        Task<List<T>> FindAll();

        Task Delete(int id);
    }
}
