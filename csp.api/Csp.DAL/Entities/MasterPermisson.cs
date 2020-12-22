using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterPermisson")]
    public partial class MasterPermisson
    {
        public int Id { get; set; }
        public int PositionId { get; set; }
        public int MenuId { get; set; }
        public bool? CreatePermisson { get; set; }
        public bool? EditPermisson { get; set; }
        public bool? ViewPermisson { get; set; }
        public bool? DeletePermisson { get; set; }
        public bool? PrintPermisson { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual Menu Menu { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterPosition Position { get; set; }
    }
}
