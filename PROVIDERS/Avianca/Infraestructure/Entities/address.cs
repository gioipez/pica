using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.B2C.Customer.Infraestructure.Entities
{
    public class address
    {
        [Key]
        public int id { get; set; }

        public int customer_id { get; set; }

        public string street { get; set; }

        public string address_type { get; set; }

        public string zip { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string country { get; set; }

        public customer customer { get; set; }
    }
}