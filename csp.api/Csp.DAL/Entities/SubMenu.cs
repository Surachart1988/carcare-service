using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class SubMenu
    {
        public SubMenu()
        {
            ExtenSubMenu = new HashSet<ExtenSubMenu>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuId { get; set; }
        public bool Status { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual ICollection<ExtenSubMenu> ExtenSubMenu { get; set; }
    }
}
