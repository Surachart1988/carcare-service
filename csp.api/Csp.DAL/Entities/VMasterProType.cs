using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class VMasterProType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ProGroupName { get; set; }
        public string Name { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
