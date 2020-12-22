using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class VMasterCarBrand
    {
        public int Id { get; set; }
        public string CarTypeName { get; set; }
        public string Name { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
