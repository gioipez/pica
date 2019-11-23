using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    public class TransporteViewModel
    {
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string fecha_salida { get; set; }
        public string num_viaje { get; set; }
        public string num_silla { get; set; }
        public string ciudad_origen { get; set; }
        public string ciudad_destino { get; set; }
        public string hora_salida { get; set; }
        public string estado_reserva { get; set; }
        public string orderId { get; set; }
    }
}
