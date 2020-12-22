using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterCarBrand")]
    public partial class MasterCarBrand
    {
        public MasterCarBrand()
        {
            Car = new HashSet<Car>();
            MasterCarModel = new HashSet<MasterCarModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CarTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterCarType CarType { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Car> Car { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterCarModel> MasterCarModel { get; set; }
    }
}
