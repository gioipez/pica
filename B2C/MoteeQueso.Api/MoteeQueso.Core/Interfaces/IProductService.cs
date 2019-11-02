using MoteeQueso.Infraestructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoteeQueso.Core.Interfaces
{
    public interface IProductService
    {
        Task<List<PRODUCTO>> GetProducts(int page, int count);

        Task<PRODUCTO> CreateProduct(PRODUCTO product);

        Task<PRODUCTO> GetProductById(int id);
    }
}