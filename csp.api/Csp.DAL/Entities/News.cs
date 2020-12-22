using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? StartDate { get; set; }
        public string NStartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string NEndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? Active { get; set; }
    }
}
