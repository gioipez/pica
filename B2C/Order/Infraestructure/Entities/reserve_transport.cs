using System;

namespace MoteeQueso.B2C.Order.Infraestructure.Entities
{
    public class reserve_transport
    {
        public int provider_id { get; set; }

        public int integration_type_id { get; set; }

        public int order_id { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public DateTime departure_date { get; set; }

        public int departure_hour { get; set; }

        public int trip_number { get; set; }

        public int chair_number { get; set; }

        public string origin { get; set; }

        public string destiny { get; set; }
    }
}