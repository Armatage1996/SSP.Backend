using System;
using System.Collections.Generic;
using System.Text;

namespace SSP.Contracts.JobSatuses
{
    class JobStatus
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
