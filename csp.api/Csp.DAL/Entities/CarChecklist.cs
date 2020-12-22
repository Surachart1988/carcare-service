using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("CarChecklist")]
    public partial class CarChecklist
    {
        public CarChecklist()
        {
            CarCheckDetail = new HashSet<CarCheckDetail>();
            CarChecklistDetail = new HashSet<CarChecklistDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public string NStartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string NEndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<CarCheckDetail> CarCheckDetail { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<CarChecklistDetail> CarChecklistDetail { get; set; }
    }
}
