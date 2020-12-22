using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterNextService")]
    public partial class MasterNextService
    {
        public MasterNextService()
        {
            MasterNextServiceSub = new HashSet<MasterNextServiceSub>();
            Product = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterNextServiceSub> MasterNextServiceSub { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Product> Product { get; set; }
    }
}
