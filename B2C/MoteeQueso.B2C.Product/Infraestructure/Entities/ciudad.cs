using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.B2C.Product.Infraestructure.Entities
{
    public class ciudad
    {
        [Key]
        public int id { get; set; }

        public string nombre { get; set; }

        public string pais { get; set; }

        public int tarifa_ciudad_id { get; set; }

        public tarifa_ciudad tarifa_ciudad { get; set; }

        public producto producto { get; set; }
    }
}