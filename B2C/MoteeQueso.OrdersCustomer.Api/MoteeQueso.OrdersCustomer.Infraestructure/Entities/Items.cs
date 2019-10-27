using System;
using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.OrdersCustomer.Infraestructure.Entities {
    public class Items {

        [Key]
        public Guid ItemId { get; set; }
        public int ProdId { get; set; }
        public string ProductName { get; set; }
        public string PartNum { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}