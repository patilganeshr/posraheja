using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class PurchaseBill
    {
        private readonly DataModel.PurchaseBill _purchaseBill;

        public PurchaseBill()
        {
            _purchaseBill = new DataModel.PurchaseBill();
        }
        
        public Boolean CheckPurchaseBillNoIsExists(Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.CheckPurchaseBillNoIsExists(purchaseBill);
        }

        public bool CheckPurchaseBillExistsInSalesBill(Int32 purchaseBillId)
        {
            return _purchaseBill.CheckPurchaseBillExistsInSalesBill(purchaseBillId);
        }

        public bool CheckPurchaseBillExistsInGoodsReceiptAndInward(Int32 purchaseBillId)
        {
            return _purchaseBill.CheckPurchaseBillExistsInGoodsReceiptAndInward(purchaseBillId);
        }

        public Boolean DeleteGoodsReceiptAndInwardByPurchaseBillId(Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.DeleteGoodsReceiptAndInwardByPurchaseBillId(purchaseBill);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.PurchaseBill> GetAllPurchaseBills()
        {
            return _purchaseBill.GetAllPurchaseBills();
        }

        public List<Entities.PurchaseBill> GetPurchaseBillsByVendor(Int32 vendorId)
        {
            return _purchaseBill.GetPurchaseBillsByVendor(vendorId);
        }

        public Entities.PurchaseBill GetPurchaseBillDetailsByID(Int32 purchaseBillId)
        {
            return _purchaseBill.GetPurchaseBillDetailsByID(purchaseBillId);
        }

        public List<Entities.ClientAddress> GetVendorsByPurchaseBillNo(Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.GetVendorsByPurchaseBillNo(purchaseBill);
        }

        public Entities.PurchaseBill GetPurchaseBillDetailsByPurchaseBillNoVendorIdAndWorkingPeriodId(Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.GetPurchaseBillDetailsByPurchaseBillNoVendorIdAndWorkingPeriodId(purchaseBill);
        }

        public Entities.PurchaseBill GetPurchaseBillDetailsByPurchaseBillNoAndWorkingPeriodId(Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.GetPurchaseBillDetailsByPurchaseBillNoAndWorkingPeriodId(purchaseBill);
        }

        public Entities.PurchaseBillItem GetItemDetailsForPurchaseByItemId(Int32 itemId)
        {
            return _purchaseBill.GetItemDetailsForPurchaseByItemId(itemId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseBill"></param>
        /// <returns></returns>
        public Int32 SavePurchaseBill(Entities.PurchaseBill purchaseBill)
        {
            return _purchaseBill.SavePurchaseBill(purchaseBill);

        }

    }
}
