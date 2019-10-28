using Microsoft.EntityFrameworkCore;
using MoteeQueso.OrdersCustomer.Infraestructure.Entities;

namespace MoteeQueso.OrdersCustomer.Infraestructure.Data
{
    public class B2CEntities : DbContext
    {
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=orderscustomer.cktjmln9ob1w.us-west-2.rds.amazonaws.com;Integrated Security=false;Initial Catalog=OrdersCustomer;user id=administrator;password=qwerty09876;");
        }
    }
}