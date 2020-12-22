using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("Sale")]
    public partial class Sale
    {
        //public Sale()
        //{
        //    AssessmentGroup = new HashSet<AssessmentGroup>();
        //    CarCheckDetail = new HashSet<CarCheckDetail>();
        //    Payment = new HashSet<Payment>();
        //    TaxItemDetail = new HashSet<TaxItemDetail>();
        //}

        public int Id { get; set; }
        public string Code { get; set; }
        public int? ContactId { get; set; }
        public string CarChasis { get; set; }
        public string CarRegis { get; set; }
        public int? Mileage { get; set; }
        public int? LastMileage { get; set; }
        public int? MileageAvgPerDay { get; set; }
        public int? DocTypeId { get; set; }
        public int? InvoiceTypeId { get; set; }
        public int? VatTypeId { get; set; }
        public int? VatRateId { get; set; }
        public DateTime? CancelAt { get; set; }
        public int? CancelBy { get; set; }
        public string RecMemo { get; set; }
        public decimal? SalePrice { get; set; }
        public decimal? SalePriceVat { get; set; }
        public decimal? SalePriceIncludeVat { get; set; }
        public int DocParentId { get; set; }
        public string DocRef { get; set; }
        public DateTime? DocRefDate { get; set; }
        public int? SaleStatusId { get; set; }
        public int? BookingId { get; set; }
        public int? TagDetailsId { get; set; }
        public int? TagStatusId { get; set; }
        public int? TagTelFalse { get; set; }
        public int? TagScore { get; set; }
        public DateTime? PaymentDuedate { get; set; }
        public string ChqNo { get; set; }
        public DateTime? ChqDate { get; set; }
        public DateTime? ChqClearingDate { get; set; }
        public int? PayChqTypeId { get; set; }
        public int? BankId { get; set; }
        public string BankBranch { get; set; }
        public int? BookBankId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Pic4 { get; set; }
        public string Pic5 { get; set; }
        public string Pic6 { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual SaleDetail SaleDetail { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual Product Product { get; set; }


        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterBank Bank { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterBookBank BookBank { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual Booking Booking { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual Contact Contact { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual DocumentType DocType { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterPayChqType PayChqType { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterTagDetails TagDetails { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterTagStatus TagStatus { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<AssessmentGroup> AssessmentGroup { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<CarCheckDetail> CarCheckDetail { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Payment> Payment { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<TaxItemDetail> TaxItemDetail { get; set; }
    }
}
