using MoteeQueso.B2C.Product.Infraestructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoteeQueso.B2C.Product.Core.Interfaces
{
    public interface IProductService
    {
        Task<List<producto>> GetProductsByQuery(string query, int page, int count);

        Task<producto> GetProductById(int id);
    }
}