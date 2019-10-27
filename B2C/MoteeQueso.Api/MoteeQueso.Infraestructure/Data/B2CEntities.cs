using Microsoft.EntityFrameworkCore;
using MoteeQueso.Infraestructure.Entities;

namespace MoteeQueso.Infraestructure.Data
{
    public class B2CEntities : DbContext
    {        
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=EFLOREZ_PC;Integrated Security=true;Initial Catalog=B2C;");
        }
    }
}