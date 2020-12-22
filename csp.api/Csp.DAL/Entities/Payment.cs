using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int? PayTypeId { get; set; }
        public string CreditCardNo { get; set; }
        public int? CreditcardId { get; set; }
        public int? CardUseTypeId { get; set; }
        public string ChqNo { get; set; }
        public int? PayChqTypeId { get; set; }
        public DateTime? ChqDate { get; set; }
        public int? BankId { get; set; }
        public string BankBranch { get; set; }
        public decimal? Amount { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? CouponId { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? DepositId { get; set; }
        public int? PromotionId { get; set; }

        public virtual MasterBank Bank { get; set; }
        public virtual MasterCardUseType CardUseType { get; set; }
        public virtual MasterCreditCard Creditcard { get; set; }
        public virtual MasterPayChqType PayChqType { get; set; }
        public virtual MasterPayType PayType { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
