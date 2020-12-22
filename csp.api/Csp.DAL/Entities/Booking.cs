using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class Booking
    {
        public Booking()
        {
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public int CarId { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int BookingStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Car Car { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
