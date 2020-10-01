using System;
using System.Collections.Generic;
using System.Text;

namespace SSP.Contracts.Jobs
{
    class Job
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public Guid TreatmentId { get; set; }
        public Guid StatusId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
