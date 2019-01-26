using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class SalesOrderController : ApiController
    {
        private readonly Business.SalesOrder _salesOrder;

        public SalesOrderController()
        {
            _salesOrder = new Business.SalesOrder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllSalesOrders")]
        public List<Entities.SalesOrder> GetAllSalesOrders()
        {
            return _salesOrder.GetAllSalesOrders();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [Route("GetSalesOrdersByCustomerId/{customerId}")]
        public List<Entities.SalesOrder> GetSalesOrdersByCustomerId(Int32 customerId)
        {
            return _salesOrder.GetSalesOrdersByCustomerId(customerId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesOrderId"></param>
        /// <returns></returns>
        [Route("GetSalesOrderDetailsBySalesOrderId/{salesOrderId}")]
        public Entities.SalesOrder GetSalesOrderDetailsBySalesOrderId(Int32 salesOrderId)
        {
            return _salesOrder.GetSalesOrderDetailsBySalesOrderId(salesOrderId);
        }

        [HttpPost]
        [Route("SaveSalesOrder")]
        public Int32 SaveSalesOrder(List<Entities.SalesOrder> salesOrders)
        {
            return _salesOrder.SaveSalesOrder(salesOrders);
        }

    }
}
