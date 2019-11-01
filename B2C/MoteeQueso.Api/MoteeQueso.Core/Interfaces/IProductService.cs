using MoteeQueso.Infraestructure.Entities;
using System.Collections.Generic;

namespace MoteeQueso.Core.Interfaces
{
    public interface IProductService
    {
        List<PRODUCTO> GetProducts(int page, int count);
        PRODUCTO CreateProduct(PRODUCTO product);
        PRODUCTO GetProductById(int id);
    }
}