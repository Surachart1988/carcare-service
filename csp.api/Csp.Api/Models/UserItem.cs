using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Csp.Api.Models
{
    public class UserItem
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string PositionName { get; set; }
        public string Phone { get; set; }
        public bool? Active { get; set; }
    }
}
