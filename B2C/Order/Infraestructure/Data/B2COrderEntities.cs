using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoteeQueso.B2C.Order.Infraestructure.Entities;
using System;

namespace MoteeQueso.B2C.Order.Infraestructure.Data
{
    public class B2COrderEntities : DbContext
    {
        public virtual DbSet<order> order { get; set; }

        public virtual DbSet<item> item { get; set; }
        
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<status>()
               .HasOne(c => c.order)
               .WithOne(e => e.status)
               .HasForeignKey<order>(b => b.status_id);

            builder.Entity<item>()
                .HasOne(e => e.order)
                .WithMany(c => c.items)
                .HasForeignKey(b => b.order_id);
        }
    }
}