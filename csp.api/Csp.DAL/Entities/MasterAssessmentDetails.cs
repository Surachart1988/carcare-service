using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterAssessmentDetails")]
    public partial class MasterAssessmentDetails
    {
        public MasterAssessmentDetails()
        {
            AssessmentGroup = new HashSet<AssessmentGroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AssessmentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterAssessment Assessment { get; set; }
        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<AssessmentGroup> AssessmentGroup { get; set; }
    }
}
