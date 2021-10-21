using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;
using SC.ProyectoAPIV3Core2.Domain.Entities.Entities;
using Microsoft.Extensions.Configuration;

namespace SC.ProyectoAPIV3Core2.DrivenAdapters.Sql
{
    public class ScDbContext : DbContext
    {
        public ScDbContext(DbContextOptions options)
            :base(options) { 

        }

        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Credito> Creditos { get; set; }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ScDbContext>
    {
        public ScDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ScDbContext>();
            var connectionString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectionString);
            return new ScDbContext(builder.Options);
        }
    }




}

 
