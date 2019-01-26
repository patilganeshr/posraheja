using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class GoodsReceipt
    {
        private readonly DataModel.GoodsReceipt _goodsReceipt;

        public GoodsReceipt()
        {
            _goodsReceipt = new DataModel.GoodsReceipt();
        }

        public List<Entities.PurchaseBill> GetVendors()
        {
            return _goodsReceipt.GetVendors();
        }

        public List<Entities.PurchaseBill> GetPendingPurchaseBills(Int32 vendorId)
        {
            return _goodsReceipt.GetPendingPurchaseBills(vendorId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillId"></param>
        /// <returns></returns>
        public List<Entities.GoodsReceiptItem> GetPurchaseBillItems(Int32 purchaseBillId)
        {
            return _goodsReceipt.GetPurchaseBillItems(purchaseBillId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.GoodsReceipt> GetAllGoodsReceipts()
        {
            return _goodsReceipt.GetAllGoodsReceipts();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBillId"></param>
        /// <returns></returns>
        public List<Entities.GoodsReceipt> GetGoodsReceiptsByPuchaseBillId(Int32 purchaseBillId)
        {
            return _goodsReceipt.GetGoodsReceiptsByPurchaseBillId(purchaseBillId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vendorId"></param>
        /// <returns></returns>
        public List<Entities.GoodsReceipt> GetGoodsReceiptsByVendorId(Int32 vendorId)
        {
            return _goodsReceipt.GetGoodsReceiptsByVendorId(vendorId);
        }

        public bool CheckGoodsReceiptExistsInSalesBill(Int32 goodsReceiptId)
        {
            return _goodsReceipt.CheckGoodsReceiptExistsInSalesBill(goodsReceiptId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goodsReceipt"></param>
        /// <returns></returns>
        public Int32 SaveGoodsReceipt(List<Entities.GoodsReceipt> goodsReceipt)
        {
            var goodsReceiptId = _goodsReceipt.SaveGoodsReceipt(goodsReceipt);

            //SaveInwardDetails(goodsReceiptId);

            return goodsReceiptId;
        }

        //private Int32 SaveInwardDetails(Int32 goodsReceiptId)
        //{
        //    return 0;// _goodsReceipt.saveInwardDetails(goodsReceiptId);
        //}

    }
}
