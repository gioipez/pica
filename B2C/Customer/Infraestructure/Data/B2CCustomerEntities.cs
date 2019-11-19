using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoteeQueso.B2C.Customer.Infraestructure.Entities;
using System;

namespace MoteeQueso.B2C.Customer.Infraestructure.Data
{
    public class B2CCustomerEntities : DbContext
    {
        public virtual DbSet<credit_card_type> credit_card_type { get; set; }

        public virtual DbSet<status> status { get; set; }

        public virtual DbSet<customer> customer { get; set; }

        public virtual DbSet<address> address { get; set; }

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
            builder.Entity<credit_card_type>()
               .HasOne(c => c.customer)
               .WithOne(e => e.credit_card_type)
               .HasForeignKey<customer>(b => b.credit_card_type_id);

            builder.Entity<status>()
               .HasOne(c => c.customer)
               .WithOne(e => e.status)
               .HasForeignKey<customer>(b => b.status_id);

            builder.Entity<address>()
                .HasOne(e => e.customer)
                .WithMany(c => c.addresses)
                .HasForeignKey(b => b.customer_id);
        }
    }
}