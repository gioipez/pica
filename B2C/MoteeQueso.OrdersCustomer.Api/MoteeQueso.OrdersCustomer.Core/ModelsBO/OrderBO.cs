using System;
using System.Collections.Generic;
using System.Text;

namespace MoteeQueso.OrdersCustomer.Core.ModelsBO
{
    public class OrderBO
    {
        public List<ItemsBO> Items { get; set; }
        public string CustId { get; set; }
        public decimal Price { get; set; }
        public string Comments { get; set; }

    }

    public class ItemsBO {

        public int ProdId { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }

    }
}
