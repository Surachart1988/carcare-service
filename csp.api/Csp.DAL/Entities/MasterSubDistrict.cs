using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterSubDistrict")]
    public partial class MasterSubDistrict
    {
        public MasterSubDistrict()
        {
            Contact = new HashSet<Contact>();
            MasterZipCode = new HashSet<MasterZipCode>();
        }

        public int Id { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterDistrict District { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterProvince Province { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Contact> Contact { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterZipCode> MasterZipCode { get; set; }
    }
}
