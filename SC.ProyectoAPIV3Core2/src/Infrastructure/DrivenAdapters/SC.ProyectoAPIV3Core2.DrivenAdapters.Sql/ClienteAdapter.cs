using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities
{
    /// <summary>
    /// EntityAdapter
    /// </summary>
    public class ClienteAdapter : IClienteRepository<Cliente>
    {
        private readonly ScDbContext context;

        public ClienteAdapter(ScDbContext context)
        {
            this.context = context;
            
        }
        public async Task<Cliente>Add(Cliente cliente)
        {
            context.Add(cliente);
            await context.SaveChangesAsync();
            return cliente;
            
        }

        public async  Task<List<Cliente>> FindAll()
            
        {
            
            return await context.Clientes.Include(s => s.Creditos).ToListAsync();
             
            
        }

        public async Task<Cliente> FindById(int ClienteId)
        {
             return await context.Clientes.Include(s => s.Creditos).FirstOrDefaultAsync(i => i.Id==ClienteId);

        }

        public async Task< int > Update(Cliente cliente)
        {
            var cliente_DB = await context.Clientes.FindAsync(cliente.Id);
            //var check_client_exist = context.Clientes.Where(x => x.Id == cliente.Id).FirstOrDefault();
            if (cliente_DB != null)
            {
                context.Entry(cliente_DB).State = EntityState.Detached;
            }
            else 
            {
                return 0;
            }
            context.Entry(cliente).State = EntityState.Modified;
            return await context.SaveChangesAsync();
            //return cliente;
           
        }

        public async Task Delete(int id)
        {
            var cliente = await context.Clientes.FindAsync(id);
            //var clienteId = await context.Clientes.Select(x => x.Id).FirstOrDefaultAsync(x => x == id);
            // check if local is not null 
            if (cliente != null)
            {
                // detach
                context.Entry(cliente).State = EntityState.Deleted;

            }
           

            // save 
            await context.SaveChangesAsync();
            

        }
    }
}
