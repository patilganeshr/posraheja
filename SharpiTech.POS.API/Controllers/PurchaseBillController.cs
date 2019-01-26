using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class PurchaseBillController : ApiController
    {
        private readonly Business.PurchaseBill _purchaseBill;

        public PurchaseBillController()
        {
            _purchaseBill = new Business.PurchaseBill();
        }

        [HttpPost]
        [Route("CheckPurchaseBillNoIsExists")]
        public Boolean CheckPurchaseBillNoIsExists(Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.CheckPurchaseBillNoIsExists(purchaseBill);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllPurchaseBills")]
        public List<Entities.PurchaseBill> GetAllPurchaseBills()
        {
            return _purchaseBill.GetAllPurchaseBills();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        [Route("GetPurchaseBillsByVendor/{vendorId}")]
        public List<Entities.PurchaseBill> GetPurchaseBillsByVendor(Int32 vendorId)
        {
            return _purchaseBill.GetPurchaseBillsByVendor(vendorId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillId"></param>
        /// <returns></returns>
        [Route("GetPurchaseBillDetailsByID/{purchaseBillId}")]
        public Entities.PurchaseBill GetPurchaseBillDetailsByID(Int32 purchaseBillId)
        {
            return _purchaseBill.GetPurchaseBillDetailsByID(purchaseBillId);
        }

        [HttpPost]
        [Route("GetVendorsByPurchaseBillNo")]
        public List<Entities.ClientAddress> GetVendorsByPurchaseBillNo([FromBody] Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.GetVendorsByPurchaseBillNo(purchaseBill);
        }

        [HttpPost]
        [Route("GetPurchaseBillDetailsByPurchaseBillNoVendorIdAndWorkingPeriodId")]
        public Entities.PurchaseBill GetPurchaseBillDetailsByPurchaseBillNoVendorIdAndWorkingPeriodId([FromBody] Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.GetPurchaseBillDetailsByPurchaseBillNoVendorIdAndWorkingPeriodId(purchaseBill);
        }

        [HttpPost]
        [Route("GetPurchaseBillDetailsByPurchaseBillNoAndWorkingPeriodId")]
        public Entities.PurchaseBill GetPurchaseBillDetailsByPurchaseBillNoAndWorkingPeriodId([FromBody] Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.GetPurchaseBillDetailsByPurchaseBillNoAndWorkingPeriodId(purchaseBill);
        }

        [Route("GetItemDetailsForPurchaseByItemId/{itemId}")]
        public Entities.PurchaseBillItem GetItemDetailsForPurchaseByItemId(Int32 itemId)
        {
            return _purchaseBill.GetItemDetailsForPurchaseByItemId(itemId);
        }

        [HttpGet]
        [Route("CheckPurchaseBillExistsInSalesBill/{purchaseBillId}")]
        public bool CheckPurchaseBillExistsInSalesBill(Int32 purchaseBillId)
        {
            return _purchaseBill.CheckPurchaseBillExistsInSalesBill(purchaseBillId);
        }

        [HttpGet]
        [Route("CheckPurchaseBillExistsInGoodsReceiptAndInward/{purchaseBillId}")]
        public bool CheckPurchaseBillExistsInGoodsReceiptAndInward(Int32 purchaseBillId)
        {
            return _purchaseBill.CheckPurchaseBillExistsInGoodsReceiptAndInward(purchaseBillId);
        }

        [HttpPost]
        [Route("DeleteGoodsReceiptAndInwardByPurchaseBillId")]
        public Boolean DeleteGoodsReceiptAndInwardByPurchaseBillId(Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.DeleteGoodsReceiptAndInwardByPurchaseBillId(purchaseBill);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBill"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SavePurchaseBill")]
        public Int32 SavePurchaseBill(Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.SavePurchaseBill(purchaseBill);

        }

    }
}
