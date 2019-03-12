using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class PurchaseOrderItem
    {
        private readonly DataModel.PurchaseOrderItem _purchaseOrderItem;

        public PurchaseOrderItem()
        {
            _purchaseOrderItem = new DataModel.PurchaseOrderItem();
        }

        public List<Entities.PurchaseOrderItem> GetPurchaseOrderItemsByPuchaseOrderId(Int32 purchaseOrderId)
        {
            return _purchaseOrderItem.GetPurchaseOrderItemsByPuchaseOrderId(purchaseOrderId);
        }
        
    }

}
