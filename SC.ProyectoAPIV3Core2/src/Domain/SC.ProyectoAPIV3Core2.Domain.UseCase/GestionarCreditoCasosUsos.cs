
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Domain.UseCase
{
    /// <summary>
    /// Caso de uso para gestionar Creditos
    /// </summary>
    public class GestionarCreditoCasosUsos
    {

        private readonly ICreditoRepositorio<Credito> creditorepositorio;
        private readonly ClienteAdaptador clientadaptador;
        private readonly IClienteRepositorio<Cliente> clienterepositorio;

        /// <summary>
        /// inicializa una nueva instancia de <see cref="GestionarCreditoCasosUsos"/> class.
        /// </summary>
        /// <param name="creditorepositorio">The creditorepositorio.</param>
        /// <param name="clienteadaptador">The clienteadaptador.</param>
        /// <param name="clienterepositorio">The clienterepositorio.</param>
        public GestionarCreditoCasosUsos(ICreditoRepositorio<Credito> creditorepositorio, ClienteAdaptador clienteadaptador, IClienteRepositorio<Cliente> clienterepositorio)
        {
            this.creditorepositorio = creditorepositorio;
            this.clienterepositorio = clienterepositorio;
            this.clientadaptador = clienteadaptador;

        }
        /// <summary>
        /// Encontrars the por identifier.
        /// </summary>
        /// <param name="creditoId">The credito identifier.</param>
        /// <returns></returns>
        public async Task<Credito> EncontrarPorId(int creditoId)
        {
            return await creditorepositorio.EncontrarPorId(creditoId);


        }

        /// <summary>
        /// Encontrars  todo.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Credito>> EncontrarTodo()
        {

            return await creditorepositorio.EncontrarTodo();

        }

        /// <summary>
        /// Añadirs  credito.
        /// </summary>
        /// <param name="credito">The credito.</param>
        /// <returns></returns>
        public async Task<Credito> AñadirCredito(Credito credito)
        {
            // calcula el maximo plazo
            var plazo_maximo = CalcularPlazoMaximo(credito);
            if (credito.Plazo > plazo_maximo)
            {
                return credito = null;

            }
            //verifica si el cliente tiene cupo
            if (ComprobarClienteCupo(credito))
            {
                var cliente = clienterepositorio.EncontrarPorId(credito.ClienteId).Result;
                var credito_creado = await creditorepositorio.Añadir(credito);
                cliente.Cupo = cliente.Cupo - credito.Valor_capital;
                clientadaptador.Actualizar(cliente);
                return credito_creado;
            }
            return credito = null;
        }
        public bool ComprobarClienteCupo(Credito credito)
        {
            var cliente = clientadaptador.EncontrarPorId(credito.ClienteId).Result;
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

        /// <summary>
        /// Calcular  plazo maximo.
        /// </summary>
        /// <param name="credito">The credito.</param>
        /// <returns></returns>
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
