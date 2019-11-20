using MoteeQueso.B2C.Order.Infraestructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoteeQueso.B2C.Order.Core.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrder(order order);

        Task UpdateOrderStatus(int id, int status_id);

        Task<order> GetOrder(int id);

        Task<List<order>> GetOrders(int customer_id, int page, int count);
    }
}