using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.B2C.Product.Infraestructure.Entities
{
    public class tarifa_espectaculo
    {
        [Key]
        public int id { get; set; }

        public string nombre_tipo { get; set; }

        public decimal precio { get; set; }

        public producto producto { get; set; }
    }
}