using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class MasterContactPayType
    {
        public MasterContactPayType()
        {
            MasterContactType = new HashSet<MasterContactType>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? DeletedBy { get; set; }

        public virtual ICollection<MasterContactType> MasterContactType { get; set; }
    }
}
