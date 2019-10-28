using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoteeQueso.OrdersCustomer.Api.ViewModels
{
    public class CustomerViewModel
    {
        public string CustId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public string Status { get; set; }
    }
}
