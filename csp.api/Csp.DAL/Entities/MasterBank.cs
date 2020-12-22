using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterBank")]
    public partial class MasterBank
    {
        public MasterBank()
        {
            MasterBookBank = new HashSet<MasterBookBank>();
            MasterCreditCard = new HashSet<MasterCreditCard>();
            Payment = new HashSet<Payment>();
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterBookBank> MasterBookBank { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<MasterCreditCard> MasterCreditCard { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Payment> Payment { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Sale> Sale { get; set; }
    }
}
