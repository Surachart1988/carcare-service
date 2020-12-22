using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class Movement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SaleDetailId { get; set; }
        public int LocationId { get; set; }
        public int? QtyFirst { get; set; }
        public int? QtyInc { get; set; }
        public int? QtyDec { get; set; }
        public int QtyAmount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual MasterLocation Location { get; set; }
        public virtual Product Product { get; set; }
        public virtual SaleDetail SaleDetail { get; set; }
    }
}
