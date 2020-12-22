using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class VMasterAssessment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public string OptionName { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
