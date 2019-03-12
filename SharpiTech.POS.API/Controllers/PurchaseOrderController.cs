using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class PurchaseOrderController : ApiController
    {
        private readonly Business.PurchaseOrder _purchaseOrder;

        public PurchaseOrderController()
        {
            _purchaseOrder = new Business.PurchaseOrder();
        }

        [Route("GetAllPurchaseOrders")]
        public List<Entities.PurchaseOrder> GetAllPurchaseOrders()
        {
            return _purchaseOrder.GetAllPurchaseOrders();
        }

        [Route("GetPurchaseOrderDetailsByID/{purchaseOrderId}")]
        public Entities.PurchaseOrder GetPurchaseOrderDetailsByID(Int32 purchaseOrderId)
        {
            return _purchaseOrder.GetPurchaseOrderDetailsByID(purchaseOrderId);
        }

        [HttpPost]
        [Route("SavePurchaseOrder")]
        public Int32 SavePurchaseOrder(Entities.PurchaseOrder purchaseOrder)
        {
            return _purchaseOrder.SavePurchaseOrder(purchaseOrder);
        }


    }
}
