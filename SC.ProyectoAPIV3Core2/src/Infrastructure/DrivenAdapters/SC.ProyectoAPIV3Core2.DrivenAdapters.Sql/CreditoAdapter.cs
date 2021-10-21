using Microsoft.EntityFrameworkCore;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities
{
    public class CreditoAdapter : ICreditoRepository<Credito>
    {
        private readonly ScDbContext context;

        public CreditoAdapter(ScDbContext context)
        {
            this.context = context;

        }

        public async Task<List<Credito>> FindAll()
        {
            return await context.Creditos.ToListAsync();
        }

        public async Task<Credito> Add(Credito credito)
        {
            context.Add(credito);
            var returned = await context.SaveChangesAsync();
            Console.WriteLine(returned);
            return credito;

        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

       

        public async Task<Credito> FindById(int creditoId)
        {
            return await context.Creditos.FindAsync(creditoId);
        }

        public Task<int> Update(Credito credito)
        {
            throw new NotImplementedException();
        }
    }
}
