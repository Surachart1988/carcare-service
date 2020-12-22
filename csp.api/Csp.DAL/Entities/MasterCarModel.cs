using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterCarModel")]
    public partial class MasterCarModel
    {
        public MasterCarModel()
        {
            Car = new HashSet<Car>();
            MasterCarSubModel = new HashSet<MasterCarSubModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CarBrandId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterCarBrand CarBrand { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Car> Car { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterCarSubModel> MasterCarSubModel { get; set; }
    }
}
