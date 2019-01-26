using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class SalesReturnBillController : ApiController
    {
        private readonly Business.SalesReturnBill _salesReturnBill;
        private readonly Business.SalesReturnBillItem _salesReturnBillItem;

        public SalesReturnBillController()
        {
            _salesReturnBill = new Business.SalesReturnBill();
            _salesReturnBillItem = new Business.SalesReturnBillItem();
        }

        [HttpPost]
        [Route("CheckSalesReturnBillNoIsExists")]
        public bool CheckSalesReturnBillNoIsExists([FromBody] Entities.SalesReturnBill salesReturnBill)
        {
            return _salesReturnBill.CheckSalesReturnBillNoIsExists(salesReturnBill);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("GetAllSalesReturnBill")]
        public List<Entities.SalesReturnBill> GetAllSalesReturnBill()
        {
            return _salesReturnBill.GetAllSalesReturnBill();
        }

        [Route("GetSalesReturnBillsBySalesType/{salesTypeId}")]
        public List<Entities.SalesReturnBill> GetSalesReturnBillsBySalesType(Int32 salesTypeId)
        {
            return _salesReturnBill.GetSalesReturnBillsBySalesType(salesTypeId);
        }

        [HttpPost]
        [Route("GetConsigneeFromSalesBills")]
        public List<Entities.ClientAddress> GetConsigneeFromSalesBills([FromBody] Entities.SalesReturnBill salesReturnBill)
        {
            return _salesReturnBill.GetConsigneeFromSalesBills(salesReturnBill);
        }

        [Route("GetSalesReturnBillsByBranchWorkingPeriodAndSalesType/{branchId}/{workingPeriodId}/{salesTypeId}")]
        public List<Entities.SalesReturnBill> GetSalesReturnBillsByBranchWorkingPeriodAndSalesType(Int32 branchId, Int32 workingPeriodId, Int32 salesTypeId)
        {
            return _salesReturnBill.GetSalesReturnBillsByBranchWorkingPeriodAndSalesType(branchId, workingPeriodId, salesTypeId);
        }

        [HttpPost]
        [Route("GetSalesBillAdditionalDetails")]
        public Entities.SalesReturnBill GetSalesBillAdditionalDetails([FromBody] Entities.SalesReturnBill salesReturnBill)
        {
            return _salesReturnBill.GetSalesBillAdditionalDetails(salesReturnBill);
        }

        [Route("GetSalesReturnBillItemsBySalesReturnBillId/{salesReturnBillId}")]
        public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsBySalesReturnBillId(Int32 salesReturnBillId)
        {
            return _salesReturnBillItem.GetSalesReturnBillItemsBySalesReturnBillId(salesReturnBillId);
        }

        [Route("GetSalesReturnBillItemsByItemName/{itemName}")]
        public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsByItemName(string itemName)
        {
            return _salesReturnBillItem.GetSalesReturnBillItemsByItemName(itemName);
        }

        [Route("GetSalesReturnBillItemsByConsignee/{consigneeId}")]
        public List<Entities.SalesReturnBillItem> GetSalesReturnBillItemsByConsignee(Int32 consigneeId)
        {
            return _salesReturnBillItem.GetSalesReturnBillItemsByConsignee(consigneeId);
        }

        [Route("GetSalesBillsByConsignee/{consigneeId}")]
        public List<Entities.SalesReturnBill> GetSalesBillsByConsignee(Int32 consigneeId)
        {
            return _salesReturnBill.GetSalesBillsByConsignee(consigneeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salesReturnBills"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SaveSalesReturnBill")]
        public Int32? SaveSalesReturnBill(Entities.SalesReturnBill salesReturnBills)
        {
            return _salesReturnBill.SaveSalesReturnBill(salesReturnBills);
        }

        [HttpPost]
        [Route("PrintSalesReturnInvoice")]
        public string PrintSalesReturnInvoice(Entities.SalesReturnBill salesReturnBill)
        {
            return _salesReturnBill.generateReport(salesReturnBill);
        }


    }
}
