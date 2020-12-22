using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class PromotionCoupon
    {
        public PromotionCoupon()
        {
            Promotion = new HashSet<Promotion>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? ValueAmount { get; set; }
        public decimal? ValuePercent { get; set; }
        public bool? UseCoupon { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<Promotion> Promotion { get; set; }
    }
}
