using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class PromotionDetail
    {
        public int Id { get; set; }
        public int PromotionId { get; set; }
        public string ProductId { get; set; }
        public string ProGroupId { get; set; }
        public string ProTypeId { get; set; }
        public string ProBrandId { get; set; }
        public string ProModelId { get; set; }
        public string ProSizeId { get; set; }
        public bool? PromotionProductGive { get; set; }

        public virtual Promotion Promotion { get; set; }
    }
}
