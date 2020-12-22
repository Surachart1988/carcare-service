using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class ReportDailySalesItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ContactName { get; set; }
        public double? SalePrice { get; set; }
        public decimal? SalePriceVat { get; set; }
        public decimal? SalePriceIncludeVat { get; set; }
    }
}
