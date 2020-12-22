using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class MasterMapTaxItem
    {
        public int Id { get; set; }
        public int? TaxItemId { get; set; }
        public int? TaxItemSubId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
