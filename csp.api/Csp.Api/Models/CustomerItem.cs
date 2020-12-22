using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class CustomerItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string PrefixName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Moblie1 { get; set; }
        public string ProvinceName { get; set; }
        public string ContactTypeName { get; set; }
        public int? CustomerType { get; set; }
        public double? CreditLimit { get; set; }
        public int? Overdue { get; set; }

        public bool? Active { get; set; }
    }
}
