using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterProBrand")]
    public partial class MasterProBrand
    {
        public MasterProBrand()
        {
            MasterPromodel = new HashSet<MasterPromodel>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterProType ProType { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterPromodel> MasterPromodel { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Product> Product { get; set; }
    }
}
