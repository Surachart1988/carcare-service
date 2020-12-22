using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterProUnit")]
    public partial class MasterProUnit
    {
        public MasterProUnit()
        {
            ProductBuyUnit = new HashSet<Product>();
            ProductSaleUnit = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Product> ProductBuyUnit { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Product> ProductSaleUnit { get; set; }
    }
}
