using Microsoft.EntityFrameworkCore;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using SC.ProyectoAPIV3Core2.DrivenAdapters.Sql;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SC.ProyectoAPIV3Core2.Helpers.Commons
{
    public class DbContextHelper
    {
        private readonly ScDbContexto ScDbContexto;

        public DbContextHelper()
        {
            var optionBuilder = new DbContextOptionsBuilder<ScDbContexto>().UseInMemoryDatabase("ScReto")
                .Options;
            ScDbContexto = new ScDbContexto(optionBuilder);
            CrearDataDummy();
        }
        public async Task CrearDataDummy() 
        {
            await ScDbContexto.Database.EnsureDeletedAsync();
            await ScDbContexto.Database.EnsureCreatedAsync();
            await ScDbContexto.Clientes.AddRangeAsync(
                new Cliente() { Nombre = "pepito", Apellido = "apellido", Correo = "jucc@gmail.com", Direccion = "cra", Municipio = "Medellin", Departamento = "Armenia" ,Cupo = 2000000});
            await ScDbContexto.SaveChangesAsync();
        }
    }
}
