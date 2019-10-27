using MoteeQueso.Infraestructure.Entities;

namespace MoteeQueso.Core.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);

        Order UpdateOrder(Order order);
    }
}