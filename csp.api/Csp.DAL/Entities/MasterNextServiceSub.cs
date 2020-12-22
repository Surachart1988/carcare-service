using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterNextServiceSub")]
    public partial class MasterNextServiceSub
    {
        public MasterNextServiceSub()
        {
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int NextServiceId { get; set; }
        public int? CountMileage { get; set; }
        public int? NextDaysCount { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterNextService NextService { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Product> Product { get; set; }
    }
}
