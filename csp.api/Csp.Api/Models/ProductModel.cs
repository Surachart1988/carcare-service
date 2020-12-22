using System;

namespace Csp.Api.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public int ProGroupId { get; set; }
        public int? ProTypeId { get; set; }
        public int? ProBrandId { get; set; }
        public int? ProModelId { get; set; }
        public int? ProSizeId { get; set; }
        public string Code { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public bool FastProduct { get; set; }
        public bool CutStock { get; set; }
        public string AdditionalCode { get; set; }
        public string PartNumber { get; set; }
        public string ManufactCode { get; set; }
        //public int? VenderId { get; set; }
        //public int? NextServiceId { get; set; }
        //public int? NextServiceSubId { get; set; }
        public int? BuyUnitId { get; set; }
        public int? BuyUnitValue { get; set; }
        public int? SaleUnitId { get; set; }
        public int? SaleUnitValue { get; set; }
        public double? CostPrice { get; set; }
        public double StandardMargin { get; set; }
        public double StandardMarginAmt { get; set; }
        public ProductStatus Status { set; get; }
        public string Note { get; set; }
        public DateTime? CancelAt { get; set; }
        public ProductTypes Types { get; set; }
        public decimal ProductSalePrice { get; set; }
        public int UnitID { get; set; }
    }
}
