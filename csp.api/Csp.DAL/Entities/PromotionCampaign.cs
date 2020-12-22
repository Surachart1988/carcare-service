using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class PromotionCampaign
    {
        public PromotionCampaign()
        {
            Promotion = new HashSet<Promotion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<Promotion> Promotion { get; set; }
    }
}
