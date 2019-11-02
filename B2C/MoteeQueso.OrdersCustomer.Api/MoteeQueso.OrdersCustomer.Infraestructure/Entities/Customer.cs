using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MoteeQueso.OrdersCustomer.Infraestructure.Entities
{
    public class Customer
    {
        [Key]
        public string custid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string creditcardtype { get; set; }
        public string creditcardnumber { get; set; }
        public string status { get; set; }
    }
}
