using MoteeQueso.OrdersCustomer.Infraestructure.Entities;
using System;
using System.Collections.Generic;

namespace MoteeQueso.OrdersCustomer.Core.Interfaces {
    public interface IItemsService {
        List<Items> GetItems();
        Items CreateItem(Items item);
    }
}