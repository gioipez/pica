using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.B2C.Product.Infraestructure.Entities
{
    public class tarifa_ciudad
    {
        [Key]
        public int id { get; set; }

        public string nombre_tipo { get; set; }

        public decimal precio { get; set; }
    }
}