using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("SaleDetail")]
    public partial class SaleDetail
    {
        public SaleDetail()
        {
            Movement = new HashSet<Movement>();
        }

        public int Id { get; set; }
        public int? DocParentId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductSetId { get; set; }
        public int? PromotionId { get; set; }
        public int? LocationId { get; set; }
        public int? Dotid { get; set; }
        public double? Quantity { get; set; }
        public int? UserId { get; set; }
        public decimal? Price { get; set; }
        public decimal? DepositBath { get; set; }
        public decimal? DepositPercent { get; set; }
        public int? ReasonIncDecId { get; set; }
        public int? SerialNumber { get; set; }
        public DateTime? ClaimDate { get; set; }
        public DateTime? ClaimSentDate { get; set; }
        public DateTime? ClaimFinishDate { get; set; }
        public DateTime? ClaimAppointDate { get; set; }
        public DateTime? ClaimEndDate { get; set; }
        public string ClaimMemo { get; set; }
        public int? ClaimResultId { get; set; }
        public int? RefDocId { get; set; }
        public decimal? Balance { get; set; }
        public decimal? PayAmount { get; set; }
        public string DebtDec { get; set; }
        public string DebtInc { get; set; }
        public decimal? DebtPricePerUnit { get; set; }
        public decimal? DebtPrice { get; set; }
        public decimal? DiscountPercenr1 { get; set; }
        public decimal? DiscountPercenr2 { get; set; }
        public decimal? DiscountBath { get; set; }
        public decimal? CheckStockQty { get; set; }
        public decimal? CheckStockStatus { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterLocation Location { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual Product Product { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ProductSet ProductSet { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual Promotion Promotion { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterReasonDecInc ReasonIncDec { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Movement> Movement { get; set; }
    }
}
