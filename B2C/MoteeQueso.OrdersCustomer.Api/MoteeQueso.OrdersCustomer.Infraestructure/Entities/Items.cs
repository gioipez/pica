using System;
using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.OrdersCustomer.Infraestructure.Entities {
    public class Items {

        [Key]
        public Guid itemid { get; set; }
        public int prodid { get; set; }
        public string productname { get; set; }
        public string partnum { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public Guid ordid { get; set; }

    }
}