using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterAssessment")]
    public partial class MasterAssessment
    {
        public MasterAssessment()
        {
            AssessmentGroup = new HashSet<AssessmentGroup>();
            MasterAssessmentDetails = new HashSet<MasterAssessmentDetails>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        public virtual ICollection<AssessmentGroup> AssessmentGroup { get; set; }
        [Write(false)]
        [Computed]
        public virtual ICollection<MasterAssessmentDetails> MasterAssessmentDetails { get; set; }
    }
}
