using System;

namespace MoteeQueso.BROCKER.Transport.Infraestructure.Entities
{
    public class flight
    {
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