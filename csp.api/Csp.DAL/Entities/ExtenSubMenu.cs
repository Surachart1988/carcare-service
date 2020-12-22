using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class ExtenSubMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubMenuId { get; set; }
        public bool Status { get; set; }

        public virtual SubMenu SubMenu { get; set; }
    }
}
