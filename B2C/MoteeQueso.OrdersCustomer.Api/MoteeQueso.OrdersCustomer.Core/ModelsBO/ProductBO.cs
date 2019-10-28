using System;
using System.Collections.Generic;
using System.Text;

namespace MoteeQueso.OrdersCustomer.Core.ModelsBO
{
    public class ProductBO
    {
        public int ID { get; set; }
        public string ESPECTACULO { get; set; }
        public DateTime FECHA_ESPECTACULO { get; set; }
        public string CIUDAD_ESPECTACULO { get; set; }
        public DateTime FECHA_LLEGADA { get; set; }
        public DateTime FECHA_SALIDA { get; set; }
        public int TIPO_TRANSPORTE { get; set; }
        public int TIPO_ESPECTACULO { get; set; }
        public int TIPO_OSPEDAJE { get; set; }
    }
}
