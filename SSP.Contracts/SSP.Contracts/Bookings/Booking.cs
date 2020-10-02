using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace SSP.Contracts
{
    public class Booking
    {       
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool Deleted { get; set; }

        public Client Client { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}
