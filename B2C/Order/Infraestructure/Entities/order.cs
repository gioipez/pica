using System;
using System.Collections.Generic;

namespace MoteeQueso.B2C.Order.Infraestructure.Entities
{
    public class order
    {
        public order()
        {
            items = new List<item>();
        }

        public int id { get; set; }

        public int customer_id{ get; set; }

        public DateTime date { get; set; }

        public decimal price { get; set; }

        public int status_id { get; set; }

        public string comments { get; set; }

        public status status { get; set; }

        public List<item> items { get; set; }
    }
}