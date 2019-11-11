using System;

namespace MoteeQueso.B2C.Product.Api.ViewModels
{
    public class ProductDetailViewModel
    {
        public int id { get; set; }

        public string codigo { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public string url_imagen { get; set; }

        public DateTime fecha_espectaculo { get; set; }

        public DateTime fecha_llegada { get; set; }

        public DateTime fecha_salida { get; set; }

        public string ciudad { get; set; }

        public decimal precio { get; set; }
    }
}