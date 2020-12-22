using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class ProductSalePriceGroup
    {
        public int Id { get; set; }
        public int ContactTypeId { get; set; }
        public int? ContactId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public string NStartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string NEndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual MasterContactType ContactType { get; set; }
        public virtual Product Product { get; set; }
    }
}
