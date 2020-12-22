using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterContactType")]
    public partial class MasterContactType
    {
        public MasterContactType()
        {
            Contact = new HashSet<Contact>();
            ProductSalePriceGroup = new HashSet<ProductSalePriceGroup>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ContactPayTypeId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Contact> Contact { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<ProductSalePriceGroup> ProductSalePriceGroup { get; set; }
    }
}
