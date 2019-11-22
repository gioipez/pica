using System;
using System.Collections.Generic;
using System.Text;

namespace ReciveClients.Modelos
{
    public class UserAuth
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool is_staff { get; set; }
    }
}
