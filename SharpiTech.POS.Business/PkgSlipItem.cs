using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class PkgSlipItem
    {
        private readonly DataModel.PkgSlipItem _pkgSlipItem;

        public PkgSlipItem()
        {
            _pkgSlipItem = new DataModel.PkgSlipItem();
        }

        public List<Entities.PkgSlipItem> GetItemsByPurchaseBillIdBaleNoAndLocationId(Int32 purchaseBillId, string baleNo, Int32 locationId)
        {
            return _pkgSlipItem.GetItemsByPurchaseBillIdBaleNoAndLocationId(purchaseBillId, baleNo, locationId);
        }

        public List<Entities.PkgSlipItem> GetGoodsReceivedItems()
        {
            return _pkgSlipItem.GetGoodsReceivedItems();
        }

        public List<Entities.PkgSlipItem> GetBaleItemsByPurchaseBillIdAndLocationId(Int32 purchaseBillId, Int32 locationId)
        {
            return _pkgSlipItem.GetBaleItemsByPurchaseBillIdAndLocationId(purchaseBillId, locationId);
        }

        /// <summary>
        /// Get pkg slip items by pkg slip id
        /// </summary>
        /// <param name="pkgSlipId"></param>
        /// <returns></returns>
        public List<Entities.PkgSlipItem> GetPkgSlipItemsByPkgSlipId(Int32 pkgSlipId)
        {
            return _pkgSlipItem.GetPkgSlipItemsByPkgSlipId(pkgSlipId);
        }

        /// <summary>
        /// Save Pkg Slip Item
        /// </summary>
        /// <param name="pkgSlipItem"></param>
        /// <returns></returns>
        public Int32 SavePkgSlipItem(Entities.PkgSlipItem pkgSlipItem)
        {
            return _pkgSlipItem.SavePkgSlipItem(pkgSlipItem);
        }

    }
}
