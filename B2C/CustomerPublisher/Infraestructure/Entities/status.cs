using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.B2C.Customer.Infraestructure.Entities
{
    public class status
    {
        [Key]
        public int id { get; set; }

        public string description { get; set; }

        public customer customer { get; set; }
    }
}