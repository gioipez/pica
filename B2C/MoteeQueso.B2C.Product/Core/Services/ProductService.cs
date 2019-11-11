using Microsoft.EntityFrameworkCore;
using MoteeQueso.B2C.Product.Core.Interfaces;
using MoteeQueso.B2C.Product.Infraestructure.Data;
using MoteeQueso.B2C.Product.Infraestructure.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoteeQueso.B2C.Product.Core.Services
{
    public class ProductService : IProductService
    {
        public async Task<List<producto>> GetProductsByQuery(string query, int page, int count)
        {
            using (B2CProductEntities entities = new B2CProductEntities())
            {
                return await entities.producto.Where(x => x.codigo.Contains(query) ||
                    x.nombre.Contains(query) || x.descripcion.Contains(query))
                    .Skip((page - 1) * count)
                    .Take(count)
                    .ToListAsync();
            }
        }

        public async Task<producto> GetProductById(int id)
        {
            using (B2CProductEntities entities = new B2CProductEntities())
            {
                return await entities.producto
                    .Include(x => x.ciudad).ThenInclude(x => x.tarifa_ciudad)
                    .Include(x => x.tarifa_espectaculo)
                    .Include(x => x.tarifa_hospedaje)
                    .Include(x => x.tarifa_transporte)
                    .FirstOrDefaultAsync(x => x.id == id);
            }
        }
    }
}