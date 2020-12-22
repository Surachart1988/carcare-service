using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class CarItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ProvinceName { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string CarTypeName { get; set; }
        public string CarBrandName { get; set; }
        public string CarModelName { get; set; }
        public string Color { get; set; }
        public string Year { get; set; }
        public DateTime? CancelAt { get; set; }
    }
}
