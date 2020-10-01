using System;
using System.Collections.Generic;
using System.Text;

namespace SSP.Contracts.Clients
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set; }
        public DaDateTime?DateUpdated { get; set; }
        public bool Deleted { get; set; }

    }
}
