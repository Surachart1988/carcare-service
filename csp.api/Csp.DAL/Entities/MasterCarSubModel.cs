using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterCarSubModel")]
    public partial class MasterCarSubModel
    {
        public MasterCarSubModel()
        {
            Car = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CarModelId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterCarModel CarModel { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Car> Car { get; set; }
    }
}
