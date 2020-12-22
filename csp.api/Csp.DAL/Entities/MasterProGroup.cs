using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Dapper.Contrib.Extensions;

namespace Csp.DAL.Models
{
    [Table("MasterProGroup")]
    public partial class MasterProGroup
    {
        public MasterProGroup()
        {
            MasterProType = new HashSet<MasterProType>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterProType> MasterProType { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Product> Product { get; set; }
    }
}
