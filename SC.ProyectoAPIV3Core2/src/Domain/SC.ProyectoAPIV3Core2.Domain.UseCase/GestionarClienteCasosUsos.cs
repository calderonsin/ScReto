using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.UseCase
{
    public class GestionarClienteCasosUsos
    {
        private readonly IClienteRepositorio<Cliente> clienterepositorio;

        public GestionarClienteCasosUsos(IClienteRepositorio<Cliente> cLienterepositorio)
        {
            this.clienterepositorio = cLienterepositorio;
        }

        public async Task<List<Cliente>> EncontrarTodo()
        {

            return await clienterepositorio.EncontrarTodo();

        }

        public async Task<Cliente> EncontrarPorId(int ClienteId)
        {
            return await clienterepositorio.EncontrarPorId(ClienteId);


        }

        public async Task<Cliente> Añadir(Cliente cliente)
        {
            return await clienterepositorio.Añadir(cliente);


        }

        public async Task<int> Actualizar(Cliente cliente)
        {
            return await clienterepositorio.Actualizar(cliente);


        }

        public async Task<int> Borrar(int id)
        {
            return await clienterepositorio.Borrar(id);


        }
    }
}
