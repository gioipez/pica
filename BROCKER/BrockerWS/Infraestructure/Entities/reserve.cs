using System;

namespace MoteeQueso.Providers.Lodging.Infraestructure.Entities
{
    public class reserve
    {
        public int id { get; set; }

        public int provider_id { get; set; }

        public int integration_type_id { get; set; }

        public int agreement_id { get; set; }

        public int days { get; set; }

        public Guid filed { get; set; }
    }
}