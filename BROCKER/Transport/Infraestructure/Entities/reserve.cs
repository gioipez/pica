using System;

namespace MoteeQueso.BROCKER.Transport.Infraestructure.Entities
{
    public class reserve
    {
        public int id { get; set; }

        public int provider_id { get; set; }

        public int integration_type_id { get; set; }

        public int agreement_id { get; set; }

        public int tickets { get; set; }

        public Guid filed { get; set; }
    }
}