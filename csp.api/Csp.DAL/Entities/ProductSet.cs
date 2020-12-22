using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class ProductSet
    {
        public ProductSet()
        {
            ProductSetDetail = new HashSet<ProductSetDetail>();
            SaleDetail = new HashSet<SaleDetail>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string NStartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string NEndDate { get; set; }
        public decimal? ProductAmount { get; set; }
        public bool UsePromotion { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<ProductSetDetail> ProductSetDetail { get; set; }
        public virtual ICollection<SaleDetail> SaleDetail { get; set; }
    }
}
