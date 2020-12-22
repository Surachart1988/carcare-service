using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class Promotion
    {
        public Promotion()
        {
            PromotionDetail = new HashSet<PromotionDetail>();
            SaleDetail = new HashSet<SaleDetail>();
        }

        public int Id { get; set; }
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string NStartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string NEndDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public string NStartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string NEndTime { get; set; }
        public int? ConditionTimeId { get; set; }
        public TimeSpan? ConditionTimeStart { get; set; }
        public TimeSpan? ConditionTimeEnd { get; set; }
        public bool? AllowMutiPromotion { get; set; }
        public string AllowMutiPromotionDetail { get; set; }
        public int PromotionGroupId { get; set; }
        public string ContactTypeDetail { get; set; }
        public int? PromotionGiveTypeId { get; set; }
        public int? PromotionGiveTypeDetail { get; set; }
        public bool? PromotionGiveTypeCondition { get; set; }
        public int PromotionPriceId { get; set; }
        public double? PromotionPriceTotal { get; set; }
        public bool? PromotionGiveSameBuy { get; set; }
        public int? PromotionGiveFreeAmount { get; set; }
        public bool? PromotionGiveDiscountUnit { get; set; }
        public double? PromotionGiveDiscountAmount { get; set; }
        public int? PromotionDiscountTypeId { get; set; }
        public double? PromotionDiscountTypeAmount { get; set; }
        public int? PromotionGroupCouponId { get; set; }
        public int? CouponId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual PromotionCampaign Campaign { get; set; }
        public virtual PromotionCoupon Coupon { get; set; }
        public virtual PromotionDiscountType PromotionDiscountType { get; set; }
        public virtual PromotionGiveType PromotionGiveType { get; set; }
        public virtual PromotionGroup PromotionGroup { get; set; }
        public virtual PromotionPrice PromotionPrice { get; set; }
        public virtual ICollection<PromotionDetail> PromotionDetail { get; set; }
        public virtual ICollection<SaleDetail> SaleDetail { get; set; }
    }
}
