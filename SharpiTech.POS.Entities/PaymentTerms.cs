using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public class PaymentTerms : BaseEntity
    {
        public Int32? PaymentTermId { get; set; }

        public string TermShortCode { get; set; }

        public string TermShortDesc { get; set; }

        public string TermMeaning { get; set; }


    }
}

