
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.UseCase
{
    public class ManageCreditoUseCase
    {

        private readonly ICreditoRepository<Credito> creditorepository;
        private readonly ClienteAdapter clienteadapter;
        private readonly IClienteRepository<Cliente> clienterepository;

        public ManageCreditoUseCase(ICreditoRepository<Credito> creditoRepository,ClienteAdapter clienteadapter,IClienteRepository<Cliente> clienteRepository)
        {
            this.creditorepository = creditoRepository;
            this.clienterepository = clienteRepository;
            this.clienteadapter = clienteadapter;
            
        }

        public async Task<Credito> FindById(int creditoId)
        {
            return await creditorepository.FindById(creditoId);


        }

        public async Task<List<Credito>> Findall()
        {

            return await creditorepository.FindAll();

        }

        public async Task<Credito> Add(Credito credito)
        {
            // calculate the maximum term
            var plazo_maximo = Calcular_plazo_maximo(credito);
            if (credito.Plazo > plazo_maximo)
            {
                return credito = null;

            }
            //check if client has quota
            if (comprobar_Cliente_cupo(credito))
            {
                var cliente = clienterepository.FindById(credito.ClienteId).Result;                
                var credito_creado = await creditorepository.Add(credito);
                cliente.Cupo = cliente.Cupo - credito.Valor_capital;
                clienteadapter.Update(cliente);
                return credito_creado;



            }
            return credito = null;

              



            //return await creditorepository.Add(credito);


        } 
        public  bool  comprobar_Cliente_cupo(Credito credito) 
        {
            var cliente = clienteadapter.FindById(credito.ClienteId).Result;
            if (cliente == null){
                return false;
            }
            if (credito.Valor_capital < cliente.Cupo)
            {
                return true;

            }
            else {
                return false;
            }
        }

        public int Calcular_plazo_maximo(Credito credito)
        {
            if (credito.Valor_capital >= 0 && credito.Valor_capital <= 100000)
            {
                return 2;

            }
            else if (credito.Valor_capital > 100000 & credito.Valor_capital <= 500000)
            {
                return 4;
            }

            else if (credito.Valor_capital > 500000 & credito.Valor_capital <= 1000000)
            {
                return 6;
            }

            else if (credito.Valor_capital > 1000000)
            {
                return 12;
            }
            else 
            {
                return 0;
            }
            


        }


    }
}
