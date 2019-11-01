using Microsoft.EntityFrameworkCore;
using MoteeQueso.Infraestructure.Entities;

namespace MoteeQueso.Infraestructure.Data
{
    public class B2CEntities : DbContext
    {        
        public virtual DbSet<PRODUCTO> producto { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Server=40.121.203.28;Port=5432;Database=productos;User Id=administrator;Password=qwerty09876;");
        }
    }
}