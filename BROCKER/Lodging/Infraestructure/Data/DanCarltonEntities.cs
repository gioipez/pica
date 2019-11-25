using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoteeQueso.BROCKER.Lodging.Infraestructure.Entities;
using System;

namespace MoteeQueso.BROCKER.Lodging.Infraestructure.Data
{
    public class DanCarltonEntities : DbContext
    {
        public virtual DbSet<touresbalon_reservations> touresbalon_reservations { get; set; }

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