using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class VMasterCarModel
    {
        public int Id { get; set; }
        public string CarBrandName { get; set; }
        public string Name { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
