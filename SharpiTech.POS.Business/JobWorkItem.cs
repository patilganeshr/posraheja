using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class JobWorkItem
    {
        private readonly DataModel.JobWorkItem _jobWorkItem;

        public JobWorkItem()
        {
            _jobWorkItem = new DataModel.JobWorkItem();
        }


        public List<Entities.JobWorkItem> GetPurchaseBillItems(Int32 purchaseBillId)
        {
            return _jobWorkItem.GetPurchaseBillItems(purchaseBillId);
        }

        public List<Entities.JobWorkItem> GetJobWorkItemsFromInward(Int32 purchaseBillId, Int32 karagirId, Int32 goodsReceiptItemId)
        {
            return _jobWorkItem.GetJobWorkItemsFromInward(purchaseBillId, karagirId, goodsReceiptItemId);
        }

    }
}
