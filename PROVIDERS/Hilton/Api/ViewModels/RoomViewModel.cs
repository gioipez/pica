using System;

namespace HiltonBookingService.ViewModels
{
    public class RoomViewModel
    {
        public int id { get; set; }

        public int agreement_id { get; set; }

        public int days { get; set; }

        public Guid filed { get; set; }
    }
}