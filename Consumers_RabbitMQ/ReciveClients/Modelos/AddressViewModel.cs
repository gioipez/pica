using System;
using System.Collections.Generic;
using System.Text;

namespace ReciveClients.Modelos
{
    class AddressViewModel
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
