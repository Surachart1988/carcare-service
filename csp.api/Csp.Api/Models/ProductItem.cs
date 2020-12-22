using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class ProductItem
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string NameTh { get; set; }
        public string ProTypeName { get; set; }
        public string ProBrandName { get; set; }
        public string ProModelName { get; set; }
        public string ProSizeName { get; set; }
        public decimal CostPrice { get; set; }
    }
}
