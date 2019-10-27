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
        public List<Product> GetProducts()
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.Products.ToList();
            }
        }
    }
}