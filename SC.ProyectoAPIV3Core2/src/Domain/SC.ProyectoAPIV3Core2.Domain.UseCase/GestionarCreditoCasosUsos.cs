
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.UseCase
{
    public class GestionarCreditoCasosUsos
    {

        private readonly ICreditoRepositorio<Credito> creditorepositorio;
        private readonly ClienteAdaptador clienteadaptor;
        private readonly IClienteRepositorio<Cliente> clienterepositorio;

        public GestionarCreditoCasosUsos(ICreditoRepositorio<Credito> creditorepositorio, ClienteAdaptador clienteadaptador, IClienteRepositorio<Cliente> clienterepositorio)
        {
            this.creditorepositorio = creditorepositorio;
            this.clienterepositorio = clienterepositorio;
            this.clienteadaptor = clienteadaptador;

        }

        public async Task<Credito> EncontrarPorId(int creditoId)
        {
            return await creditorepositorio.EncontrarPorId(creditoId);


        }

        public async Task<List<Credito>> EncontrarTodo()
        {

            return await creditorepositorio.EncontrarTodo();

        }

        public async Task<Credito> AñadirCredito(Credito credito)
        {
            // calculate the maximum term
            var plazo_maximo = CalcularPlazoMaximo(credito);
            if (credito.Plazo > plazo_maximo)
            {
                return credito = null;

            }
            //check if client has quota
            if (ComprobarClienteCupo(credito))
            {
                var cliente = clienterepositorio.EncontrarPorId(credito.ClienteId).Result;
                var credito_creado = await creditorepositorio.Add(credito);
                cliente.Cupo = cliente.Cupo - credito.Valor_capital;
                clienteadaptor.Actualizar(cliente);
                return credito_creado;
            }
            return credito = null;
        }
        public bool ComprobarClienteCupo(Credito credito)
        {
            var cliente = clienteadaptor.EncontrarPorId(credito.ClienteId).Result;
            if (cliente == null)
            {
                return false;
            }
            if (credito.Valor_capital < cliente.Cupo)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public int CalcularPlazoMaximo(Credito credito)
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
