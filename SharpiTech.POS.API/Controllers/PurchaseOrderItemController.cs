using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class PurchaseOrderItemController : ApiController
    {
        private readonly Business.PurchaseOrderItem _purchaseOrderItem;

        public PurchaseOrderItemController()
        {
            _purchaseOrderItem = new Business.PurchaseOrderItem();
        }

        public List<Entities.PurchaseOrderItem> GetPurchaseOrderItemsByPuchaseOrderId(Int32 purchaseOrderId)
        {
            return _purchaseOrderItem.GetPurchaseOrderItemsByPuchaseOrderId(purchaseOrderId);
        }

    }
}
