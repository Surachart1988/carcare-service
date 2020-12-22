using System;
using System.Collections.Generic;

namespace Csp.DAL.Models
{
    public partial class DayEnd
    {
        public int Id { get; set; }
        public int? DayStartId { get; set; }
        public int DocTypeId { get; set; }
        public string Code { get; set; }
        public DateTime? Date { get; set; }
        public string NDate { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public string NTimeEnd { get; set; }
        public int? _1000count { get; set; }
        public decimal? _1000total { get; set; }
        public int? _500count { get; set; }
        public decimal? _500total { get; set; }
        public int? _100count { get; set; }
        public decimal? _100total { get; set; }
        public int? _50count { get; set; }
        public decimal? _50total { get; set; }
        public int? _20count { get; set; }
        public decimal? _20total { get; set; }
        public int? _10count { get; set; }
        public decimal? _10total { get; set; }
        public int? _5count { get; set; }
        public decimal? _5total { get; set; }
        public int? _2count { get; set; }
        public decimal? _2total { get; set; }
        public int? _1count { get; set; }
        public decimal? _1total { get; set; }
        public int? _05count { get; set; }
        public decimal? _05total { get; set; }
        public int? _025count { get; set; }
        public decimal? _025total { get; set; }
        public int? CreaditCount { get; set; }
        public decimal? CreaditTotal { get; set; }
        public int? CheqBankAmount { get; set; }
        public decimal? CheqBankTotal { get; set; }
        public decimal? SumTotal { get; set; }
        public string Note { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual DayStart DayStart { get; set; }
        public virtual DocumentType DocType { get; set; }
    }
}
