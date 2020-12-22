using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    [Table("Branch")]
    public partial class Branch
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string TaxId { get; set; }
        public string BranchType { get; set; }
        public string AddressName { get; set; }
        public string No { get; set; }
        public string Moo { get; set; }
        public string Trog { get; set; }
        public string Soi { get; set; }
        public string Road { get; set; }
        public int? ProvinceId { get; set; }
        public int? DistrictId { get; set; }
        public int? SubDistrictId { get; set; }
        public int? ZipcodeId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Emails { get; set; }
        public string Theme { get; set; }
        public string Url { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? Active { get; set; }
    }
}
