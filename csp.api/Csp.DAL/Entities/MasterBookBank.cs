using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class MasterBookBank
    {
        public MasterBookBank()
        {
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BankId { get; set; }
        public decimal Balance { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string Code { get; set; }
        public string Branch { get; set; }
        public DateTime? StartDate { get; set; }
        public string NStartDate { get; set; }
        public string Note { get; set; }
        public int BookBankType { get; set; }

        public virtual MasterBank Bank { get; set; }
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
