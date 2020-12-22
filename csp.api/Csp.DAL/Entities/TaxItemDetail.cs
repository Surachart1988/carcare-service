using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class TaxItemDetail
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int? TaxDeducId { get; set; }
        public int? TaxTypeId { get; set; }
        public int? TaxFormId { get; set; }
        public int? Row1Id { get; set; }
        public int? Row1RateId { get; set; }
        public double? Row1Price { get; set; }
        public int? Row2Id { get; set; }
        public int? Row2RateId { get; set; }
        public double? Row2Price { get; set; }
        public int? Row3Id { get; set; }
        public int? Row3RateId { get; set; }
        public double? Row3Price { get; set; }
        public int? Row4Aid { get; set; }
        public int? Row4ArateId { get; set; }
        public double? Row4Aprice { get; set; }
        public int? Row4Bid { get; set; }
        public int? Row4B11rateId { get; set; }
        public double? Row4B11price { get; set; }
        public int? Row4B12rateId { get; set; }
        public double? Row4B12price { get; set; }
        public int? Row4B13rateId { get; set; }
        public double? Row4B13price { get; set; }
        public double? Row4B14etc { get; set; }
        public int? Row4B14rateId { get; set; }
        public double? Row4B14price { get; set; }
        public int? Row4B2rateId { get; set; }
        public double? Row4B2price { get; set; }
        public int? Row4B3rateId { get; set; }
        public double? Row4B3price { get; set; }
        public int? Row5Id { get; set; }
        public int? Row5RateId { get; set; }
        public double? Row5Price { get; set; }
        public string Row6 { get; set; }
        public double? Row6Rate { get; set; }
        public double? Row6Price { get; set; }

        public virtual Sale Sale { get; set; }
    }
}
