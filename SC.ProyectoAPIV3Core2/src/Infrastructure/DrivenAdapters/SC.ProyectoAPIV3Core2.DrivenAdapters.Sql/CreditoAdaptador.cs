using Microsoft.EntityFrameworkCore;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities.Gateway;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Sql.Entities
{
    public class CreditoAdaptador : ICreditoRepositorio<Credito>
    {
        private readonly ScDbContexto contexto;

        public CreditoAdaptador(ScDbContexto contexto)
        {
            this.contexto = contexto;

        }

        public async Task<List<Credito>> EncontrarTodo()
        {
            return await contexto.Creditos.ToListAsync();
        }

        public async Task<Credito> Add(Credito credito)
        {
            contexto.Add(credito);
            await contexto.SaveChangesAsync();
            //Console.WriteLine(returned);
            return credito;

        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }



        public async Task<Credito> EncontrarPorId(int creditoId)
        {
            return await contexto.Creditos.FindAsync(creditoId);
        }

        public Task<int> Update(Credito credito)
        {
            throw new NotImplementedException();
        }
    }
}
