using System;
using System.Collections.Generic;
using System.Text;

namespace SSP.Contracts.Bookings
{
    class Booking
    {       
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Int32 BookingDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
