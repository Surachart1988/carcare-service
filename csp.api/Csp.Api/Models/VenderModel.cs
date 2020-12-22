using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class VenderModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int? ContactTypeId { get; set; }

        public string Name { get; set; }
        public string TaxId { get; set; }
        public int? BussTypeId { get; set; }
        public string CusContactName { get; set; }
        public string TaxBranchNo { get; set; }
        public string AddressNo { get; set; }
        public string AddressMoo { get; set; }

        public string AddressTrog { get; set; }
        public string AddressRoad { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int SubDistrictId { get; set; }
        public int? ZipCodeId { get; set; }
        public string Phone { get; set; }

        public string Fax { get; set; }
        public string Moblie1 { get; set; }
        public string Email { get; set; }
        public int? VatTypeId { get; set; }
        public int? VatRateId { get; set; }
        public double? CreditLimit { get; set; }
        public string CreditTerm { get; set; }
        public string Note { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public int? Overdue { get; set; }
        public bool? Active { get; set; }
        public DateTime? CancelAt { get; set; }
        public int? CancelBy { get; set; }

    }

    [Flags]
    public enum ContactTypes
    {
        vender = 1,
        customer = 2
    }
}
    