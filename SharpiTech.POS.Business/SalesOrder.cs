using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class SalesOrder
    {
        private readonly DataModel.SalesOrder _salesOrder;

        public SalesOrder()
        {
            _salesOrder = new DataModel.SalesOrder();
        }

        public List<Entities.SalesOrder> GetAllSalesOrders()
        {
            return _salesOrder.GetAllSalesOrders();
        }
        public List<Entities.SalesOrder> GetSalesOrdersByCustomerId(Int32 customerId)
        {
            return _salesOrder.GetSalesOrdersByCustomerId(customerId);
        }

        public Entities.SalesOrder GetSalesOrderDetailsBySalesOrderId(Int32 salesOrderId)
        {
            return _salesOrder.GetSalesOrderDetailsBySalesOrderId(salesOrderId);
        }

        public Int32 SaveSalesOrder(Entities.SalesOrder salesOrder)
        {
            return _salesOrder.SaveSalesOrder(salesOrder);
        }

        public Int32 SaveSalesOrder(List<Entities.SalesOrder> salesOrders)
        {
            return _salesOrder.SaveSalesOrder(salesOrders);
        }

    }
}
