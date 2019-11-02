using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoteeQueso.OrdersCustomer.Infraestructure.Entities
{
    public class Orders
    {
        [Key]
        public Guid ordid { get; set; }
        public string custid { get; set; }
        public DateTime orderdate { get; set; }
        public decimal price { get; set; }
        public string status { get; set; }
        public string comments { get; set; }

    }
}
