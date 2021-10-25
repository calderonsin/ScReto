using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway
{
    public interface IClienteRepositorio<T>
    {
        Task<T> Añadir(T cliente);
        Task<int> Actualizar(T cliente);
        Task<T> EncontrarPorId(int clienteId);

        Task<List<T>> EncontrarTodo();

        Task<int> Borrar(int id);
    }
}
