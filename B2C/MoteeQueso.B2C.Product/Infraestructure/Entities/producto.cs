using System;
using System.ComponentModel.DataAnnotations;

namespace MoteeQueso.B2C.Product.Infraestructure.Entities {
    public class producto {

        [Key]
        public int id { get; set; }

        public string codigo { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public string url_imagen { get; set; }

        public DateTime fecha_espectaculo { get; set; }

        public DateTime fecha_llegada { get; set; }

        public DateTime fecha_salida { get; set; }

        public int ciudad_id { get; set; }

        public int tarifa_transporte_id { get; set; }

        public int tarifa_espectaculo_id { get; set; }

        public int tarifa_hospedaje_id { get; set; }

        public ciudad ciudad { get; set; }

        public tarifa_transporte tarifa_transporte { get; set; }

        public tarifa_espectaculo tarifa_espectaculo { get; set; }

        public tarifa_hospedaje tarifa_hospedaje { get; set; }
    }
}