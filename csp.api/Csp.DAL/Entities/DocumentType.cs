using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("DocumentType")]
    public partial class DocumentType
    {
        public DocumentType()
        {
            DayEnd = new HashSet<DayEnd>();
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Fcode { get; set; }
        public string Format { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<DayEnd> DayEnd { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Sale> Sale { get; set; }
    }
}
