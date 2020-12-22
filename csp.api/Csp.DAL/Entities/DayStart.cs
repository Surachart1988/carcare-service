using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class DayStart
    {
        public DayStart()
        {
            DayEnd = new HashSet<DayEnd>();
        }

        public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public string NStartDate { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public string NTimeStart { get; set; }
        public decimal? Money { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        public virtual ICollection<DayEnd> DayEnd { get; set; }
    }
}
