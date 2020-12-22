using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class MasterSex
    {
        public MasterSex()
        {
            Contact = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<Contact> Contact { get; set; }
    }
}
