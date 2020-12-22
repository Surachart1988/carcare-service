using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class Menu
    {
        public Menu()
        {
            MasterPermisson = new HashSet<MasterPermisson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? MenuHeadId { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<MasterPermisson> MasterPermisson { get; set; }
    }
}
