using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.UseCase
{
    public class ManageClienteUseCase
    {
        private readonly IClienteRepository<Cliente> Clienterepository;

        public ManageClienteUseCase(IClienteRepository<Cliente> cLienteRepository) 
        {
            this.Clienterepository = cLienteRepository;
        }

        public async Task<List<Cliente>> Findall()         
        {

            return await Clienterepository.FindAll();

        }

        public async Task<Cliente> FindById(int ClienteId)
        {
            return await Clienterepository.FindById(ClienteId);
             

        }

        public async Task<Cliente> Add(Cliente cliente)
        {
            return await Clienterepository.Add(cliente);


        }

        public async Task<int> Update(Cliente cliente)
        {
            return await Clienterepository.Update(cliente);


        }

        public async Task Delete(int id)
        {
             await Clienterepository.Delete(id);


        }
    }
}
