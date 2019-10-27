using Microsoft.EntityFrameworkCore;
using MoteeQueso.Core.Interfaces;
using MoteeQueso.Infraestructure.Data;
using MoteeQueso.Infraestructure.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MoteeQueso.Core.Services
{
    public class ProductService : IProductService
    {
        public List<PRODUCTO> GetProducts()
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.PRODUCTO.ToList();
            }
        }

        public PRODUCTO CreateProduct(PRODUCTO product){
            using (B2CEntities entities = new B2CEntities())
            {
                entities.PRODUCTO.Add(product);
                entities.SaveChanges();
            }

            return product;
        }

        public PRODUCTO GetProductById(int id) {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.PRODUCTO.Where(x => x.ID == id).FirstOrDefault();
            }
        }
    }
}