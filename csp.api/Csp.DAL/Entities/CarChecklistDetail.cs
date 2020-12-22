using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class CarChecklistDetail
    {
        public int Id { get; set; }
        public int CarChecklistId { get; set; }
        public int CheckListId { get; set; }

        public virtual CarChecklist CarChecklist { get; set; }
        public virtual MasterCheckList CheckList { get; set; }
    }
}
