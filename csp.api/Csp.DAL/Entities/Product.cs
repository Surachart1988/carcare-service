using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            MasterProStock = new HashSet<MasterProStock>();
            Movement = new HashSet<Movement>();
            //ProductSalePrice = new HashSet<ProductSalePrice>();
            ProductSalePriceGroup = new HashSet<ProductSalePriceGroup>();
            ProductSetDetail = new HashSet<ProductSetDetail>();
            SaleDetail = new HashSet<SaleDetail>();
        }

        public int Id { get; set; }
        public int ProGroupId { get; set; }
        public int? ProTypeId { get; set; }
        public int? ProBrandId { get; set; }
        public int? ProModelId { get; set; }
        public int? ProSizeId { get; set; }
        public string Code { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public bool? FastProduct { get; set; }
        public string AdditionalCode { get; set; }
        public string PartNumber { get; set; }
        public string ManufactCode { get; set; }
        public int? VenderId { get; set; }
        public int? NextServiceId { get; set; }
        public int? NextServiceSubId { get; set; }
        public int? BuyUnitId { get; set; }
        public int? BuyUnitValue { get; set; }
        public int? SaleUnitId { get; set; }
        public int? SaleUnitValue { get; set; }
        public decimal? CostPrice { get; set; }
        public double StandardMargin { get; set; }
        public double StandardMarginAmt { get; set; }
        public bool CutStock { get; set; }
        public string Note { get; set; }
        public int? Status { get; set; }
        public int Types { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CancelAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? CancelBy { get; set; }
        public int UnitID { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterProUnit BuyUnit { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterNextService NextService { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterNextServiceSub NextServiceSub { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterProBrand ProBrand { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterProGroup ProGroup { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterPromodel ProModel { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterProSize ProSize { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterProType ProType { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterProUnit SaleUnit { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual Contact Vender { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterProStock> MasterProStock { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Movement> Movement { get; set; }
        //[Write(false)]
        //[Computed]
        //[JsonIgnore] public virtual ICollection<ProductSalePrice> ProductSalePrice { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<ProductSalePriceGroup> ProductSalePriceGroup { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<ProductSetDetail> ProductSetDetail { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<SaleDetail> SaleDetail { get; set; }
    }
}
