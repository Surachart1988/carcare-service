using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class VMasterNextServiceSub
    {
        public int Id { get; set; }
        public string NextServiceName { get; set; }
        public string Name { get; set; }
        public int? CountMileage { get; set; }
        public int? NextDaysCount { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
