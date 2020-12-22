using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterCheckList")]
    public partial class MasterCheckList
    {
        public MasterCheckList()
        {
            CarCheckDetail = new HashSet<CarCheckDetail>();
            CarChecklistDetail = new HashSet<CarChecklistDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Tire { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        public virtual ICollection<CarCheckDetail> CarCheckDetail { get; set; }

        [Write(false)]
        [Computed]
        public virtual ICollection<CarChecklistDetail> CarChecklistDetail { get; set; }
    }
}
