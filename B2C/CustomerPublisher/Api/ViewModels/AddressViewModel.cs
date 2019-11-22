namespace MoteeQueso.B2C.CustomerPublisher.Api.ViewModels
{
    public class AddressViewModel
    {
        public int id { get; set; }

        public string street { get; set; }

        public string address_type { get; set; }

        public string zip { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string country { get; set; }
    }
}