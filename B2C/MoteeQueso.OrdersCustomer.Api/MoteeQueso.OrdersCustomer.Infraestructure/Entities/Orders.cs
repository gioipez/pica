using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoteeQueso.OrdersCustomer.Infraestructure.Entities
{
    public class Orders
    {
        [Key]
        public Guid OrdId { get; set; }
        public string CustId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }

    }
}
