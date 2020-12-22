using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class MasterUserPermisson
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MenuId { get; set; }
        public bool? CreatePermisson { get; set; }
        public bool? EditPermisson { get; set; }
        public bool? ViewPermisson { get; set; }
        public bool? DeletePermisson { get; set; }
        public bool? PrintPermisson { get; set; }
        public byte Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? DeletedBy { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual User User { get; set; }
    }
}
