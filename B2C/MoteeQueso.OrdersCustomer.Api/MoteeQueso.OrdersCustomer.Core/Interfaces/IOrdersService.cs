using MoteeQueso.OrdersCustomer.Core.ModelsBO;
using MoteeQueso.OrdersCustomer.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoteeQueso.OrdersCustomer.Core.Interfaces
{
    public interface IOrdersService
    {
        Orders GetOrderById(Guid ordId);
        Orders Create(OrderBO order);

    }
}
