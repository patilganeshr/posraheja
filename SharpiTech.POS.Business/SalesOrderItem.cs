using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class SalesOrderItem
    {
        private readonly DataModel.SalesOrderItem _salesOrderItem;

        public SalesOrderItem()
        {
            _salesOrderItem = new DataModel.SalesOrderItem();
        }

        public List<Entities.SalesOrderItem> GetSalesOrderItemsBySalesOrderId(Int32 salesOrderId)
        {
            return _salesOrderItem.GetSalesOrderItemsBySalesOrderId(salesOrderId);
        }

        public Int32 SaveSalesOrderItem(Entities.SalesOrderItem salesOrderItem)
        {
            return _salesOrderItem.SaveSalesOrderItem(salesOrderItem);
        }

    }
}
