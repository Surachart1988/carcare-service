using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class VMasterPromodel
    {
        public int Id { get; set; }
        public string ProBrandName { get; set; }
        public string Name { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
