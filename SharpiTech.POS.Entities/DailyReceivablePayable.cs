using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class DailyReceivablePayable : BaseEntity
    {
        public Int32? DailyRecPayId { get; set; }
        
        public string EntryDate { get; set; }

        public string Particulars { get; set; }

        public decimal? Amount { get; set; }

        public decimal? ReceivableAmount { get; set; }

        public decimal? PayableAmount { get; set; }

        public string Comments { get; set; }

        public string ReceivablePayable { get; set; }
        
        public Int32? BranchId { get; set; }

        public string Flag { get; set; }

    }
}
