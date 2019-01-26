using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;

namespace SharpiTech.POS.Business
{
    public class SalesReturnBillItem
    {
        private readonly DataModel.SalesReturnBillItem _salesReturnBillItem;

        public SalesReturnBillItem()
        {
            _salesReturnBillItem = new DataModel.SalesReturnBillItem();
        }

        public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsBySalesReturnBillId(Int32 salesReturnBillId)
        {
            return _salesReturnBillItem.GetSalesReturnBillItemsBySalesReturnBillId(salesReturnBillId);
        }
                
        public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsByItemName(string itemName)
        {
            return _salesReturnBillItem.GetSalesReturnBillItemsByItemName(itemName);
        }

        public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsByConsignee(Int32 consigneeId)
        {
            return _salesReturnBillItem.GetSalesReturnBillItemsByConsignee(consigneeId);
        }

    }
}
