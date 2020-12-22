using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterLocation")]
    public partial class MasterLocation
    {
        public MasterLocation()
        {
            MasterProStock = new HashSet<MasterProStock>();
            Movement = new HashSet<Movement>();
            SaleDetail = new HashSet<SaleDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterProStock> MasterProStock { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Movement> Movement { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<SaleDetail> SaleDetail { get; set; }
    }
}
