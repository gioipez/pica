using Microsoft.EntityFrameworkCore;
using MoteeQueso.Core.Interfaces;
using MoteeQueso.Infraestructure.Data;
using MoteeQueso.Infraestructure.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoteeQueso.Core.Services
{
    public class ProductService : IProductService
    {
        public async Task<List<PRODUCTO>> GetProducts(int page, int count)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return await entities.producto.Skip((page - 1) * count).Take(count).ToListAsync();
            }
        }

        public async Task<PRODUCTO> CreateProduct(PRODUCTO product)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                entities.producto.Add(product);
                await entities.SaveChangesAsync();
            }

            return product;
        }

        public async Task<PRODUCTO> GetProductById(int id)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return await entities.producto.FirstOrDefaultAsync(x => x.id == id);
            }
        }
    }
}