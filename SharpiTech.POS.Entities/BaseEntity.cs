using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Entities
{
    public abstract class BaseEntity
    {
        public Int64? SrNo { get; set; }

        [DatabaseColumn("remarks")]
        public string Remarks { get; set; }

        [DatabaseColumn("guid")]
        public Guid? guid { get; set; }

        [DatabaseColumn("is_deleted")]
        public bool? IsDeleted { get; set; }

        [DatabaseColumn("created_by")]
        public Int32? CreatedBy { get; set; }

        [DatabaseColumn("created_by_ip")]
        public string CreatedByIP { get; set; }

        [DatabaseColumn("created_datetime")]
        public DateTime? CreatedDateTime { get; set; }

        [DatabaseColumn("modified_by")]
        public Int32? ModifiedBy { get; set; }

        [DatabaseColumn("modified_by_ip")]
        public string ModifiedByIP { get; set; }

        [DatabaseColumn("modified_datetime")]
        public DateTime? ModifiedDateTime { get; set; }

        [DatabaseColumn("cancelled_by")]
        public Int32? CancelledBy { get; set; }

        [DatabaseColumn("deleted_by")]
        public Int32? DeletedBy { get; set; }

        [DatabaseColumn("deleted_by_ip")]
        public string DeletedByIP { get; set; }

        [DatabaseColumn("deleted_datetime")]
        public DateTime? DeletedDatetime { get; set; }

        [DatabaseColumn("working_period_id")]
        public Int32? WorkingPeriodId { get; set; }

        [DatabaseColumn("financial_year")]
        public string FinancialYear { get; set; }

    }
}
