using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoteeQueso.OrdersCustomer.Api.ViewModels
{
    public class ItemViewModel
    {
        public int ProdId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
