using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class PurchaseOrder
    {
        private readonly DataModel.PurchaseOrder _purchaseOrder;

        public PurchaseOrder()
        {
            _purchaseOrder = new DataModel.PurchaseOrder();
        }

        public List<Entities.PurchaseOrder> GetAllPurchaseOrders()
        {
            return _purchaseOrder.GetAllPurchaseOrders();
        }

        public Entities.PurchaseOrder GetPurchaseOrderDetailsByID(Int32 purchaseOrderId)
        {
            return _purchaseOrder.GetPurchaseOrderDetailsByID(purchaseOrderId);
        }

        public Int32 SavePurchaseOrder(Entities.PurchaseOrder purchaseOrder)
        {
            return _purchaseOrder.SavePurchaseOrder(purchaseOrder);
        }

    }
}
