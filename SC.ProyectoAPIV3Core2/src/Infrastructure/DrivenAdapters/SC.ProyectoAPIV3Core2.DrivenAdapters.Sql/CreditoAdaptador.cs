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
        /// <summary>
        /// Encontrar todo.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Credito>> EncontrarTodo()
        {
            return await contexto.Creditos.ToListAsync();
        }
        /// <summary>
        /// Crea un credito.
        /// </summary>
        /// <param name="credito">The credito.</param>
        /// <returns></returns>
        public async Task<Credito> Añadir(Credito credito)
        {
            contexto.Add(credito);
            await contexto.SaveChangesAsync();
            //Console.WriteLine(returned);
            return credito;

        }
        /// <summary>
        /// Borrar credito.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task Borrar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Encuentro un  credito con la id creditoID.
        /// </summary>
        /// <param name="creditoId">The credito identifier.</param>
        /// <returns></returns>
        public async Task<Credito> EncontrarPorId(int creditoId)
        {
            return await contexto.Creditos.FindAsync(creditoId);
        }
        /// <summary>
        /// Actualizar credito.
        /// </summary>
        /// <param name="credito">The credito.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<int> Actualizar(Credito credito)
        {
            throw new NotImplementedException();
        }
    }
}
