using System;

namespace MoteeQueso.BROCKER.Lodging.Infraestructure.Entities
{
    public class reserve
    {
        public int provider_id { get; set; }

        public int integration_type_id { get; set; }

        public int order_id { get; set; }

        public int hotel_id { get; set; }

        public int room_number { get; set; }

        public DateTime check_in_date { get; set; }

        public DateTime check_out_date { get; set; }

        public int state { get; set; }

        public string guest_name { get; set; }
    }
}