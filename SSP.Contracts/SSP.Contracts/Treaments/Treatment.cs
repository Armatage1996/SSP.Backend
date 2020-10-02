using System;
using System.Collections.Generic;
using System.Text;

namespace SSP.Contracts
{
    public class Treatment
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Int32 Duration { get; set; }
        public double Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public bool Deleted { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
