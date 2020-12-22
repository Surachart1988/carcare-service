using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class ProductSetDetail
    {
        public int Id { get; set; }
        public int ProductSetId { get; set; }
        public int ProductId { get; set; }
        public double? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductSet ProductSet { get; set; }
    }
}
