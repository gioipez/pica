using System;

namespace MoteeQueso.B2C.Order.Api.ViewModels
{
    public class OrderViewModel
    {
        public int id { get; set; }

        public DateTime date { get; set; }

        public decimal price { get; set; }

        public string status { get; set; }
    }
}