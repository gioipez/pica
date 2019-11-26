using System;

namespace MoteeQueso.BROCKER.Lodging.Infraestructure.Entities
{
    public class room
    {
        public string order_id { get; set; }

        public int hotel_id { get; set; }

        public int room_number { get; set; }

        public DateTime check_in_date { get; set; }

        public DateTime check_out_date { get; set; }

        public int state { get; set; }

        public string guest_name { get; set; }
    }
}