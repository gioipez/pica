using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoteeQueso.OrdersCustomer.Api.ViewModels
{
    public class OrderViewModel
    {
        public List<ItemViewModel> Items { get; set; }
        public string CustId { get; set; }
        public decimal Price { get; set; }
        public string Comments { get; set; }        
    }
}
