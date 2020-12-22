using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Csp.Api.Models
{
    public class PermissionModel
    {
        [Required]
        public int PositionID { get; set; }

        [Required]
        public int MenuID { get; set; }
    }
}
