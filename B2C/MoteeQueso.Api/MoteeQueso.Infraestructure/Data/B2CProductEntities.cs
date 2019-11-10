using Microsoft.EntityFrameworkCore;
using MoteeQueso.B2C.Product.Infraestructure.Entities;

namespace MoteeQueso.B2C.Product.Infraestructure.Data
{
    public class B2CProductEntities : DbContext
    {        
        public virtual DbSet<ciudad> ciudad { get; set; }

        public virtual DbSet<producto> producto { get; set; }

        public virtual DbSet<tarifa_ciudad> tarifa_ciudad { get; set; }

        public virtual DbSet<tarifa_espectaculo> tarifa_espectaculo { get; set; }

        public virtual DbSet<tarifa_hospedaje> tarifa_hospedaje { get; set; }

        public virtual DbSet<tarifa_transporte> tarifa_transporte { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql(@"Server=40.121.203.28;Port=5432;Database=productos;User Id=administrator;Password=qwerty09876;");
            optionsBuilder.UseSqlServer(@"Server=EFLOREZ_PC;Integrated Security=true;Initial Catalog=B2C;");
        }
    }
}