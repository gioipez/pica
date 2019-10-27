using MoteeQueso.OrdersCustomer.Core.Interfaces;
using MoteeQueso.OrdersCustomer.Infraestructure.Data;
using MoteeQueso.OrdersCustomer.Infraestructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoteeQueso.OrdersCustomer.Core.Services {

    public class ItemService : IItemsService
    {
        public Items CreateItem(Items item)
        {
            using (B2CEntities entities = new B2CEntities())
            {
                entities.Items.Add(item);
                entities.SaveChanges();
            }

            return item;
        }

        public List<Items> GetItems()
        {
            using (B2CEntities entities = new B2CEntities())
            {
                return entities.Items.ToList();
            }
        }
    }

}