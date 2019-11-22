using System;

namespace ServicioWebAvianca.ViewModels
{
    public class VueloViewModel
    {
        public int id { get; set; }

        public int convenio_id { get; set; }

        public int tiquetes { get; set; }

        public Guid radicado { get; set; }
    }
}