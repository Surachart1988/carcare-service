using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterProStock")]
    public partial class MasterProStock
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int LocationId { get; set; }
        public int Dotid { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterDot Dot { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterLocation Location { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual Product Product { get; set; }
    }
}
