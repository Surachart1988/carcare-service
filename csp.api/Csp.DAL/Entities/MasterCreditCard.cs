using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Csp.DAL.Models
{
    [Table("MasterCreditCard")]
    public partial class MasterCreditCard
    {
        public MasterCreditCard()
        {
            Payment = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BankId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual MasterBank Bank { get; set; }

        [Write(false)]
        [Computed]
        [JsonIgnore] public virtual ICollection<Payment> Payment { get; set; }
    }
}
