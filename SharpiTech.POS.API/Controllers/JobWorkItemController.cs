using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class JobWorkItemController : ApiController
    {
        private readonly Business.JobWorkItem _jobWorkItem;
        private readonly Business.JobWorkItemMtrAdjustment _jobWorkItemMtrAdjustment;

        public JobWorkItemController()
        {
            _jobWorkItem = new Business.JobWorkItem();
            _jobWorkItemMtrAdjustment = new Business.JobWorkItemMtrAdjustment();
        }

        [Route("GetJobWorkPurchaseBillItems/{purchaseBillId}")]
        public List<Entities.JobWorkItem> GetJobWorkPurchaseBillItems(Int32 purchaseBillId)
        {
            return _jobWorkItem.GetPurchaseBillItems(purchaseBillId);
        }

        [Route("GetJobWorkItemsFromInward/{purchaseBillId}/{karagirId}/{goodsReceiptItemId}")]
        public List<Entities.JobWorkItem> GetJobWorkItemsFromInward(Int32 purchaseBillId, Int32 karagirId, Int32 goodsReceiptItemId)
        {
            return _jobWorkItem.GetJobWorkItemsFromInward(purchaseBillId, karagirId, goodsReceiptItemId);
        }

        [Route("GetJobWorkItemReferenceNoDetails/{pkgSlipId}")]
        public List<Entities.JobWorkItemMtrAdjustment> GetJobWorkItemReferenceNoDetails(Int32 pkgSlipId)
        {
            return _jobWorkItemMtrAdjustment.GetJobWorkItemReferenceNoDetails(pkgSlipId);
        }


    }
}
