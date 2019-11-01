using MoteeQueso.Core.Interfaces;
using MoteeQueso.Infraestructure.Data;
using MoteeQueso.Infraestructure.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MoteeQueso.Core.Services
{
    public class ProductService : IProductService
    {
        public List<PRODUCTO> GetProducts(int page, int count)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.producto.Skip((page - 1) * count).Take(count).ToList();
            }
        }

        public PRODUCTO CreateProduct(PRODUCTO product)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                entities.producto.Add(product);
                entities.SaveChanges();
            }

            return product;
        }

        public PRODUCTO GetProductById(int id)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.producto.FirstOrDefault(x => x.id == id);
            }
        }
    }
}
