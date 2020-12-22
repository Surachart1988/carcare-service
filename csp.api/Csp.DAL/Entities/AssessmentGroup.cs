using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("AssessmentGroup")]
    public partial class AssessmentGroup
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int AssessmentId { get; set; }
        public int AssetmentDetailsId { get; set; }

        [Write(false)]
        [Computed]
        public virtual MasterAssessment Assessment { get; set; }
        [Write(false)]
        [Computed]
        public virtual MasterAssessmentDetails AssetmentDetails { get; set; }
        [Write(false)]
        [Computed]
        public virtual Sale Sale { get; set; }
    }
}
