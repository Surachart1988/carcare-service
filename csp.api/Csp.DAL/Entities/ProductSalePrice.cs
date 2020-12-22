using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("ProductSalePrice")]
    public partial class ProductSalePrice
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime PriceDate { get; set; }
        public string NPriceDate { get; set; }
        public decimal Price { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual Product Product { get; set; }
    }
}
