using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class MasterPayType
    {
        public MasterPayType()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
