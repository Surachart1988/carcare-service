using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class VMasterProBrand
    {
        public int Id { get; set; }
        public string ProTypeName { get; set; }
        public string Name { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
