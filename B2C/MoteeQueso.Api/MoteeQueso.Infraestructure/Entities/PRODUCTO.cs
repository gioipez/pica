using System;
using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.Infraestructure.Entities {
    public class PRODUCTO {

        [Key]
        public int id { get; set; }
        public string espectaculo { get; set; }
        public DateTime fecha_espectaculo { get; set; }
        public string ciudad_espectaculo { get; set; }
        public DateTime fecha_llegada { get; set; }
        public DateTime fecha_salida { get; set; }
        public int tipo_transporte { get; set; }
        public int tipo_espectaculo { get; set; }
        public int tipo_ospedaje { get; set; }

    }

}