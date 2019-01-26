using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class PkgSlip
    {
        private readonly DataModel.PkgSlip _pkgSlip;

        public PkgSlip()
        {
            _pkgSlip = new DataModel.PkgSlip();
        }

        public List<Entities.PkgSlip> GetVendors()
        {
            return _pkgSlip.GetVendors();
        }

        public List<Entities.PkgSlip> GetBaleNosByVendorId(Int32 vendorId)
        {
            return _pkgSlip.GetBaleNosByVendorId(vendorId);
        }

        public List<Entities.PkgSlip> GetPurchaseBillNosByVendorId(Int32 vendorId)
        {
            return _pkgSlip.GetPurchaseBillNosByVendorId(vendorId);
        }

        public List<Entities.PkgSlip> GetFromLocationsByPurchaseBillid(Int32 purchaseBillId)
        {
            return _pkgSlip.GetFromLocationsByPurchaseBillid(purchaseBillId);
        }

        /// <summary>
        /// Get all pkg slips
        /// </summary>
        /// <returns></returns>
        public List<Entities.PkgSlip> GetAllPkgSlips()
        {
            return _pkgSlip.GetAllPkgSlips();
        }

        /// <summary>
        /// Save pkg slip
        /// </summary>
        /// <param name="pkgSlip"></param>
        /// <returns></returns>
        public Int32 SavePkgSlip(Entities.PkgSlip pkgSlip)
        {
            return _pkgSlip.SavePkgSlip(pkgSlip);
        }


    }
}
