using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class GoodsReceiptController : ApiController
    {
        private readonly Business.GoodsReceipt _goodsReceipt;

        public GoodsReceiptController()
        {
            _goodsReceipt = new Business.GoodsReceipt();
        }

        [Route("GetPendingVendors")]
        public List<Entities.PurchaseBill> GetVendors()
        {
            return _goodsReceipt.GetVendors();
        }

        [Route("GetPendingPurchaseBills/{vendorId}")]
        public List<Entities.PurchaseBill> GetPendingPurchaseBills(Int32 vendorId)
        {
            return _goodsReceipt.GetPendingPurchaseBills(vendorId);
        }

        [Route("GetPurchaseBillItems/{purchaseBillId}")]
        public List<Entities.GoodsReceiptItem> GetPurchaseBillItems(Int32 purchaseBillId)
        {
            return _goodsReceipt.GetPurchaseBillItems(purchaseBillId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllGoodsReceipts")]
        public List<Entities.GoodsReceipt> GetAllGoodsReceipts()
        {
            return _goodsReceipt.GetAllGoodsReceipts();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillId"></param>
        /// <returns></returns>
        [Route("GetGoodsReceiptsByPuchaseBillId/{purchaseBillId}")]
        public List<Entities.GoodsReceipt> GetGoodsReceiptsByPuchaseBillId(Int32 purchaseBillId)
        {
            return _goodsReceipt.GetGoodsReceiptsByPuchaseBillId(purchaseBillId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        [Route("GetGoodsReceiptsByVendorId/{vendorId}")]
        public List<Entities.GoodsReceipt> GetGoodsReceiptsByVendorId(Int32 vendorId)
        {
            return _goodsReceipt.GetGoodsReceiptsByVendorId(vendorId);
        }

        [HttpGet]
        [Route("CheckGoodsReceiptExistsInSalesBill/{goodsReceiptId}")]
        public bool CheckGoodsReceiptExistsInSalesBill(Int32 goodsReceiptId)
        {
            return _goodsReceipt.CheckGoodsReceiptExistsInSalesBill(goodsReceiptId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceipt"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveGoodsReceipt")]
        public Int32 SaveGoodsReceipt(List<Entities.GoodsReceipt> goodsReceipt)
        {
            return _goodsReceipt.SaveGoodsReceipt(goodsReceipt);
        }


    }
}
