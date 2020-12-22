using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class MasterPayCheckType
    {
        public MasterPayCheckType()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? DeletedBy { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
