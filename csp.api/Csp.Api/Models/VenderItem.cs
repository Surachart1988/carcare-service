using Csp.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class VenderItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string CusContactName { get; set; }
        public int? Overdue { get; set; }
        public string CreditTerm { get; set; }
        public bool? Active { get; set; }
    }
}
