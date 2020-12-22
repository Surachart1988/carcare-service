using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class CarCheckDetail
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int CarChecklistId { get; set; }
        public int CheckListId { get; set; }
        public string TireDepth { get; set; }
        public string TireWind { get; set; }
        public bool? CheckStatus { get; set; }
        public string Note { get; set; }

        public virtual CarChecklist CarChecklist { get; set; }
        public virtual MasterCheckList CheckList { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
