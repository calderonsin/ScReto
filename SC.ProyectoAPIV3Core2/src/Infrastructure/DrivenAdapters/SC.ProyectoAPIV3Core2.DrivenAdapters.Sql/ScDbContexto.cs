using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using System.IO;

namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Sql
{
    public class ScDbContexto : DbContext
    {
        public ScDbContexto(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Credito> Creditos { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ScDbContexto>
    {
        public ScDbContexto CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ScDbContexto>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectionString);
            return new ScDbContexto(builder.Options);
        }
    }




}


