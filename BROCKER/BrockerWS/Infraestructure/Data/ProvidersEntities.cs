using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoteeQueso.Providers.Lodging.Infraestructure.Entities;
using System;

namespace MoteeQueso.Providers.Lodging.Infraestructure.Data
{
    public class ProvidersEntities : DbContext
    {
        public virtual DbSet<provider> provider { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            
            string connectionString = configuration.GetValue<string>("DefaultConnection");

            if (connectionString == "SQLServer")
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQLServer"));
            }
            else
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            }
        }
    }
}