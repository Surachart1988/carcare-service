using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterProvince")]
    public partial class MasterProvince
    {
        public MasterProvince()
        {
            Car = new HashSet<Car>();
            Contact = new HashSet<Contact>();
            MasterDistrict = new HashSet<MasterDistrict>();
            MasterSubDistrict = new HashSet<MasterSubDistrict>();
            MasterZipCode = new HashSet<MasterZipCode>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Car> Car { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Contact> Contact { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterDistrict> MasterDistrict { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterSubDistrict> MasterSubDistrict { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterZipCode> MasterZipCode { get; set; }
    }
}
