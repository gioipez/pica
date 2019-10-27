using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoteeQueso.OrdersCustomer.Api.ViewModels
{
    public class ItemsViewModel
    {
        public Guid ItemId { get; set; }
        public int ProdId { get; set; }
        public string ProductName { get; set; }
        public string PartNum { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
