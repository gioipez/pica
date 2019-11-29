using System;
using System.Collections.Generic;
using System.Text;

namespace MoteeQueso.B2C.Order.Infraestructure.Entities
{
    public class item
    {
        public int id { get; set; }

        public int product_id { get; set; }

        public string product_name { get; set; }

        public decimal price { get; set; }

        public int quantity { get; set; }

        public int order_id { get; set; }

        public int product_type_id { get; set; }

        public int product_integration_type_id { get; set; }

        public order order { get; set; }
    }
}