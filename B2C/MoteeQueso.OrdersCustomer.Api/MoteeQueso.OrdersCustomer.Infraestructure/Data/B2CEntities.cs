using Microsoft.EntityFrameworkCore;
using MoteeQueso.OrdersCustomer.Infraestructure.Entities;

namespace MoteeQueso.OrdersCustomer.Infraestructure.Data
{
    public class B2CEntities : DbContext
    {
        public virtual DbSet<Items> items { get; set; }
        public virtual DbSet<Customer> customer { get; set; }
        public virtual DbSet<Orders> orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=40.121.203.28;Port=5432;Database=productos;User Id=administrator;Password=qwerty09876;");
        }
    }
}