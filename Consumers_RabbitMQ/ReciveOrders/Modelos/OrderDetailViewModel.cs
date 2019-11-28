using System;
using System.Collections.Generic;
using System.Text;

namespace ReciveOrders.Modelos
{
    class OrderDetailViewModel
    {
        public OrderDetailViewModel()
        {
            items = new List<ItemViewModel>();
        }

        public int id { get; set; }

        public int customer_id { get; set; }

        public DateTime date { get; set; }

        public decimal price { get; set; }

        public int status_id { get; set; }

        public string comments { get; set; }

        public List<ItemViewModel> items { get; set; }
    }
}
