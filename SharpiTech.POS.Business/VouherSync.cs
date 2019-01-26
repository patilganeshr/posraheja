using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class VoucherSync
    {
        private readonly DataModel.VoucherSync _voucherSync;

        public VoucherSync()
        {
            _voucherSync = new DataModel.VoucherSync();
        }

        public List<Entities.VoucherType> GetVoucherType()
        {
            return _voucherSync.GetVoucherType();
        }

        public Int32 PostVoucherDataToTally(Entities.VoucherSync voucherSync)
        {
            return _voucherSync.PostVoucherDataToTally(voucherSync);
        }

    }

}
