using MoteeQueso.Infraestructure.Entities;
using System.Collections.Generic;

namespace MoteeQueso.Core.Interfaces
{
    public interface IProductService
    {
        List<PRODUCTO> GetProducts();
        PRODUCTO CreateProduct(PRODUCTO product);
    }
}