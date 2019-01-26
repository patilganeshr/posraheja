using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class PurchaseBillItem
    {
        private readonly DataModel.PurchaseBillItem _purchaseBillItem;

        public PurchaseBillItem()
        {
            _purchaseBillItem = new DataModel.PurchaseBillItem();
        }

        public List<Entities.PurchaseBillItem> GetPurchaseBillItemsByPuchaseBillId(Int32 purchaseBillId)
        {
            return _purchaseBillItem.GetPurchaseBillItemsByPuchaseBillId(purchaseBillId);
        }

        public Int32 SavePurchaseBillItem(Entities.PurchaseBillItem purchaseBillItem)
        {
            return _purchaseBillItem.SavePurchaseBillItem(purchaseBillItem);
        }

    }
}
