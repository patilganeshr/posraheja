using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class PkgSlipController : ApiController
    {
        private readonly Business.PkgSlip _pkgSlip;
        private readonly Business.PkgSlipItem _pkgSlipItem;

        public PkgSlipController()
        {
            _pkgSlip = new Business.PkgSlip();
            _pkgSlipItem = new Business.PkgSlipItem();
        }

        [Route("GetVendorsForPkgSlip")]
        public List<Entities.PkgSlip> GetVendorsForPkgSlip()
        {
            return _pkgSlip.GetVendors();
        }

        [Route("GetBaleNosByVendorId/{vendorId}")]
        public List<Entities.PkgSlip> GetBaleNosByVendorId(Int32 vendorId)
        {
            return _pkgSlip.GetBaleNosByVendorId(vendorId);
        }

        [Route("GetPurchaseBillNosByVendorId/{vendorId}")]
        public List<Entities.PkgSlip> GetPurchaseBillNosByVendorId(Int32 vendorId)
        {
            return _pkgSlip.GetPurchaseBillNosByVendorId(vendorId);
        }

        [Route("GetFromLocationsByPurchaseBillid/{purchaseBillId}")]
        public List<Entities.PkgSlip> GetFromLocationsByPurchaseBillid(Int32 purchaseBillId)
        {
            return _pkgSlip.GetFromLocationsByPurchaseBillid(purchaseBillId);
        }

        [Route("GetItemsByPurchaseBillIdBaleNoAndLocationId/{purchaseBillId}/{baleNo}/{locationId}")]
        public List<Entities.PkgSlipItem> GetItemsByPurchaseBillIdBaleNoAndLocationId(Int32 purchaseBillId, string baleNo, Int32 locationId)
        {
            return _pkgSlipItem.GetItemsByPurchaseBillIdBaleNoAndLocationId(purchaseBillId, baleNo, locationId);
        }

        [Route("GetBaleItemsByPurchaseBillIdAndLocationId/{purchaseBillId}/{locationId}")]
        public List<Entities.PkgSlipItem> GetBaleItemsByPurchaseBillIdAndLocationId(Int32 purchaseBillId, Int32 locationId)
        {
            return _pkgSlipItem.GetBaleItemsByPurchaseBillIdAndLocationId(purchaseBillId, locationId);
        }

        [HttpPost]
        [Route("GetPkgSlipItemsByBarcodeOrItemName")]
        public List<Entities.PkgSlipItem> GetPkgSlipItemsByBarcodeOrItemName(Entities.PkgSlipItem pkgSlipItem)
        {
            return _pkgSlipItem.GetPkgSlipItemsByBarcodeOrItemName(pkgSlipItem);
        }

        [Route("GetGoodsReceivedItems")]
        public List<Entities.PkgSlipItem> GetGoodsReceivedItems()
        {
            return _pkgSlipItem.GetGoodsReceivedItems();
        }

        /// <summary>
        /// Get all pkg slips
        /// </summary>
        /// <returns></returns>
        [Route("GetAllPkgSlips")]
        public List<Entities.PkgSlip> GetAllPkgSlips()
        {
            return _pkgSlip.GetAllPkgSlips();
        }

        /// <summary>
        /// Save pkg slip
        /// </summary>
        /// <param name="pkgSlip"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SavePkgSlip")]
        public Int32 SavePkgSlip(Entities.PkgSlip pkgSlip)
        {
            return _pkgSlip.SavePkgSlip(pkgSlip);
        }
    }
}
