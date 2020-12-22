﻿using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    [Table("Contact")]
    public partial class Contact
    {
        //public Contact()
        //{
        //    Car = new HashSet<Car>();
        //    Product = new HashSet<Product>();
        //    ProductSalePriceGroup = new HashSet<ProductSalePriceGroup>();
        //    Sale = new HashSet<Sale>();
        //}

        public int Id { get; set; }
        public string Code { get; set; }
        public int? ContactTypeId { get; set; }
        public int? PrefixId { get; set; }
        public string Name { get; set; }
        public int? Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string TaxId { get; set; }
        public int? BussTypeId { get; set; }
        public string CusContactName { get; set; }
        public int? CustomerType { get; set; }
        public int? InvoiceTypeId { get; set; }
        public string TaxBranch { get; set; }
        public string TaxBranchNo { get; set; }
        public int? VenderOrderType { get; set; }
        public DateTime? FirstContactDate { get; set; }
        public DateTime? LastContactDate { get; set; }
        public DateTime? CancelAt { get; set; }
        public int? CancelBy { get; set; }
        public string Address { get; set; }
        public string AddressNo { get; set; }
        public string AddressMoo { get; set; }
        public string AddressSoi { get; set; }
        public string AddressTrog { get; set; }
        public string AddressRoad { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int SubDistrictId { get; set; }
        public int? ZipCodeId { get; set; }
        public string Phone { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Fax { get; set; }
        public string Moblie1 { get; set; }
        public string Moblie2 { get; set; }
        public string Moblie3 { get; set; }
        public string Email { get; set; }
        public int? ContactPayTypeId { get; set; }
        public int? VatTypeId { get; set; }
        public int? VatRateId { get; set; }
        public double? CreditLimit { get; set; }
        public double? CreditBalance { get; set; }
        public string DepositAmount { get; set; }
        public string CreditTerm { get; set; }
        public string DayBillPay { get; set; }
        public string DayReceiveChq { get; set; }
        public string WorkCompany { get; set; }
        public string WorkTypeId { get; set; }
        public string WorkPosition { get; set; }
        public string WorkSection { get; set; }
        public string WorkTower { get; set; }
        public string WorkFloor { get; set; }
        public string WorkNo { get; set; }
        public string WorkSoi { get; set; }
        public string WorkTrog { get; set; }
        public string WorkRoad { get; set; }
        public int? WorkProvinceId { get; set; }
        public int? WorkDistrictId { get; set; }
        public int? WorkSubDistrictId { get; set; }
        public int? WorkZipCodeId { get; set; }
        public string WorkPhone1 { get; set; }
        public string WorkPhone2 { get; set; }
        public string WorkPhone3 { get; set; }
        public string WorkFax { get; set; }
        public string WorkMoblie1 { get; set; }
        public string WorkMoblie2 { get; set; }
        public string WorkMoblie3 { get; set; }
        public string WorkEmail { get; set; }
        public string Note { get; set; }
        public int? NewsSentTypes { get; set; }
        public bool? NewsLetterType { get; set; }
        public int Types { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? Overdue { get; set; }
        public bool? Active { get; set; }

        [Write(false)]
        [Computed]
        public virtual MasterBussinessType BussType { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterContactType ContactType { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterDistrict District { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterPrefix Prefix { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterProvince Province { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterSubDistrict SubDistrict { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterVatType VatType { get; set; }
        [Write(false)]
        [Computed]
        public virtual ICollection<Car> Car { get; set; }
        [Write(false)]
        [Computed]
        public virtual ICollection<Product> Product { get; set; }
        [Write(false)]
        [Computed]
        public virtual ICollection<ProductSalePriceGroup> ProductSalePriceGroup { get; set; }
        [Write(false)]
        [Computed]
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
