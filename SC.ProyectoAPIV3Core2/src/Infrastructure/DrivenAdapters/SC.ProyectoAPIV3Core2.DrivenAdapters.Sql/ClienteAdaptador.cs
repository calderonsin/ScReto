using Microsoft.EntityFrameworkCore;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities
{
    /// <summary>
    /// ClienteAdaptador
    /// </summary>
    public class ClienteAdaptador : IClienteRepositorio<Cliente>
    {
        private readonly ScDbContexto contexto;

        public ClienteAdaptador(ScDbContexto contexto)
        {
            this.contexto = contexto;

        }
        /// <summary>
        /// Añadir cliente.
        /// </summary>
        /// <param name="cliente">The cliente.</param>
        /// <returns></returns>
        public async Task<Cliente> Añadir(Cliente cliente)
        {
            contexto.Add(cliente);
            await contexto.SaveChangesAsync();
            return cliente;

        }

        /// <summary>
        /// Mostrar  todo.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Cliente>> MostrarTodo()

        {

            return await contexto.Clientes.Include(s => s.Creditos).ToListAsync();


        }
        /// <summary>
        /// Encontrars por id.
        /// </summary>
        /// <param name="ClienteId">The cliente identifier.</param>
        /// <returns></returns>
        public async Task<Cliente> EncontrarPorId(int ClienteId)
        {
            return await contexto.Clientes.Include(s => s.Creditos).FirstOrDefaultAsync(i => i.Id == ClienteId);

        }

        /// <summary>
        /// Actualizars cliente.
        /// </summary>
        /// <param name="cliente">The cliente.</param>
        /// <returns></returns>
        public async Task<int> Actualizar(Cliente cliente)
        {
            var cliente_DB = await contexto.Clientes.FindAsync(cliente.Id);
            //var check_client_exist = contexto.Clientes.Where(x => x.Id == cliente.Id).FirstOrDefault();
            if (cliente_DB != null)
            {
                contexto.Entry(cliente_DB).State = EntityState.Detached;
            }
            else
            {
                return 0;
            }
            contexto.Entry(cliente).State = EntityState.Modified;
            return await contexto.SaveChangesAsync();
            //return cliente;

        }

        /// <summary>
        /// Borrar cliente.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<int> Borrar(int id)
        {
            var cliente = await contexto.Clientes.FindAsync(id);
            if (cliente != null)
            {
                // detach
                contexto.Entry(cliente).State = EntityState.Deleted;

            }


            // save 
            return await contexto.SaveChangesAsync();


        }
    }
}
