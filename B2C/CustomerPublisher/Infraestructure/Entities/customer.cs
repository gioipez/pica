using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.B2C.Customer.Infraestructure.Entities
{
    public class customer
    {
        [Key]
        public int id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string phone_number { get; set; }

        public string email { get; set; }

        public int credit_card_type_id { get; set; }

        public string credit_card_number { get; set; }

        public int status_id { get; set; }

        public credit_card_type credit_card_type { get; set; }

        public status status { get; set; }

        public List<address> addresses { get; set; }
    }
}