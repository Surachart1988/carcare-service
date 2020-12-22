using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterCarType")]
    public partial class MasterCarType
    {
        public MasterCarType()
        {
            Car = new HashSet<Car>();
            MasterCarBrand = new HashSet<MasterCarBrand>();
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
        [JsonIgnore] public virtual ICollection<MasterCarBrand> MasterCarBrand { get; set; }
    }
}
