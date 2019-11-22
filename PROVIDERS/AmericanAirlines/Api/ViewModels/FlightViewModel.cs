using System;

namespace AAFlightsService.ViewModels
{
    public class FlightViewModel
    {
        public int id { get; set; }

        public int agreement_id { get; set; }

        public int tickets { get; set; }

        public Guid filed { get; set; }
    }
}