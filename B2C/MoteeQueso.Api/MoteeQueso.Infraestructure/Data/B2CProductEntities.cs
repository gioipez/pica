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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<tarifa_ciudad>().HasOne(p => p.ciudad).WithOne(p => p.tarifa_ciudad).HasForeignKey<ciudad>(p => p.tarifa_ciudad_id);
            builder.Entity<ciudad>().HasOne(p => p.producto).WithOne(p => p.ciudad).HasForeignKey<producto>(p => p.ciudad_id);
            builder.Entity<tarifa_espectaculo>().HasOne(p => p.producto).WithOne(p => p.tarifa_espectaculo).HasForeignKey<producto>(p => p.tarifa_espectaculo_id);
            builder.Entity<tarifa_hospedaje>().HasOne(p => p.producto).WithOne(p => p.tarifa_hospedaje).HasForeignKey<producto>(p => p.tarifa_hospedaje_id);
            builder.Entity<tarifa_transporte>().HasOne(p => p.producto).WithOne(p => p.tarifa_transporte).HasForeignKey<producto>(p => p.tarifa_transporte_id);
        }
    }
}