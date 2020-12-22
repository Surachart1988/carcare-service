using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class ReportServiceRequestItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string ContactName { get; set; }
        public string CarChasis { get; set; }
        public int? Mileage { get; set; }
        public string ProductCode { get; set; }
        public string ProductNameTH { get; set; }
        public double? SaleDetailQuantity { get; set; }
        public decimal? SaleDetailPrice { get; set; }
        public decimal? SaleDetailBalance { get; set; }
        public int? SaleStatusId { get; set; }
    }
}
