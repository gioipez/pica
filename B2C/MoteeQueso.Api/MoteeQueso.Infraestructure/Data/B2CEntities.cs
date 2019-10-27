using Microsoft.EntityFrameworkCore;
using MoteeQueso.Infraestructure.Entities;

namespace MoteeQueso.Infraestructure.Data
{
    public class B2CEntities : DbContext
    {        
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=tb-productos.cktjmln9ob1w.us-west-2.rds.amazonaws.com;Integrated Security=false;Initial Catalog=productos;user id=administrator;password=qwerty09876;");
        }
    }
}