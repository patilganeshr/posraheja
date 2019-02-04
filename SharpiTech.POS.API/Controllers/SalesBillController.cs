using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class SalesBillController : ApiController
    {
        private readonly Business.SalesBill _salesBill;
        private readonly Business.ModeOfPayment _modeOfPayment;
        private readonly Business.PaymentSettlement _paymentSettlement;
        private readonly Business.SalesBillItem _salesBillItem;

        public SalesBillController()
        {
            _salesBill = new Business.SalesBill();
            _salesBillItem = new Business.SalesBillItem();
            _modeOfPayment = new Business.ModeOfPayment();
            _paymentSettlement = new Business.PaymentSettlement();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        [Route("GetSalesBillsByBranchId/{branchId}/{workingPeriodId}")]
        public List<Entities.SalesBill> GetSalesBillsByBranchId(Int32 branchId, Int32 workingPeriodId)
        {
            return _salesBill.GetSalesBillsByBranchId(branchId, workingPeriodId);
        }

        [Route("GetSalesBillsBySaleType/{branchId}/{workingPeriodId}/{saleTypeId}")]
        public List<Entities.SalesBill> GetSalesBillsBySaleType(Int32 branchId, Int32 workingPeriodId, Int32 saleTypeId)
        {
            return _salesBill.GetSalesBillsBySaleType(branchId, workingPeriodId, saleTypeId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="workingPeriodId"></param>
        /// <returns></returns>
        [Route("GetSalesBillsByCustomerId/{customerId}/{workingPeriodId}")]
        public List<Entities.SalesBill> GetSalesBillsByCustomerId(Int32 customerId, Int32 workingPeriodId)
        {
            return _salesBill.GetSalesBillsByCustomerId(customerId, workingPeriodId);
        }

        [Route("GetSalesBillDetailsByWorkingPeriodSaleTypeAndSalesBillNo/{workingPeriodId}/{saleTypeId}/{salesBillNo}")]
        public Entities.SalesBill GetSalesBillDetailsByWorkingPeriodSaleTypeAndSalesBillNo(Int32 workingPeriodId, Int32 saleTypeId, Int32 salesBillNo)
        {
            return _salesBill.GetSalesBillDetailsByWorkingPeriodSaleTypeAndSalesBillNo(workingPeriodId, saleTypeId, salesBillNo);
        }

        [HttpPost]
        [Route("SaveSalesBill")]
        public Int32 SaveSalesBill(Entities.SalesBill salesBill)
        {
            return _salesBill.SaveSalesBill(salesBill);
        }

        [HttpPost]
        [Route("PrintCashSaleInvoice")]
        public string PrintCashSaleInvoice(Entities.SalesBill salesBill)
        {
            return _salesBill.generateReport(salesBill);
        }

        [HttpGet]
        [Route("GetTypeOfSales")]
        public List<Entities.TypeOfSale> GetTypeOfSales()
        {
            return _salesBill.GetTypeOfSales();
        }

        [HttpPost]
        [Route("CheckSalesBillNoIsExists")]
        public bool CheckSalesBillNoIsExists([FromBody] Entities.SalesBill salesBill)
        {
            return _salesBill.CheckSalesBillNoIsExists(salesBill);
        }

        [HttpPost]
        [Route("CancelSalesBill")]
        public bool CancelSalesBill(Entities.SalesBill salesBill)
        {
            return _salesBill.CancelSalesBill(salesBill);
        }

        [Route("GetItemListByGoodsReceiptBarcode/{goodsReceiptItemId}")]
        public Entities.SalesBillItem GetItemListByGoodsReceiptBarcode(Int32 goodsReceiptItemId)
        {
            return _salesBill.GetItemsListByGoodsReceiptBarcode(goodsReceiptItemId);
        }

        [Route("GetItemsListByGoodsReceiptAndInwardGoodsBarcode/{goodsReceiptItemId}/{inwardGoodsId}")]
        public Entities.SalesBillItem GetItemsListByGoodsReceiptAndInwardGoodsBarcode(Int32 goodsReceiptItemId, Int32 inwardGoodsId)
        {
            return _salesBill.GetItemsListByGoodsReceiptAndInwardGoodsBarcode(goodsReceiptItemId, inwardGoodsId);
        }

        [Route("GetItemDetailsByItemId/{itemId}")]
        public Entities.SalesBillItem GetItemDetailsByItemId(Int32 itemId)
        {
            return _salesBill.GetItemDetailsByItemId(itemId);
        }

        [Route("GetModeOfPayments")]
        public List<Entities.ModeOfPayment> GetModeOfPayments()
        {
            return _modeOfPayment.GetModeOfPayments();
        }

        [Route("GetPaymentSettlements")]
        public List<Entities.PaymentSettlement> GetPaymentSettlements()
        {
            return _paymentSettlement.GetPaymentSettlements();
        }

        [HttpGet]
        [Route("SearchSaleItemByItemName/{itemName}")]
        public List<Entities.SalesBillItem> SearchSaleItemByItemName(string itemName)
        {
            return _salesBillItem.SearchSaleItemByItemName(itemName);
        }

        [Route("GetSalesBillItemsBySalesBillId/{salesBillId}")]
        public List<Entities.SalesBillItem> GetSalesBillItemsBySalesBillId(Int32 salesBillId)
        {
            return _salesBillItem.GetSalesBillItemsBySalesBillId(salesBillId);
        }

        [HttpGet]
        [Route("GetSaleRateHistoryByCustomerAndItem/{customerId}/{itemId}")]
        public List<Entities.SalesBill> GetSaleRateHistoryByCustomerAndItem(Int32 customerId, Int32 itemId)
        {
            return _salesBill.GetSaleRateHistoryByCustomerAndItem(customerId, itemId);
        }

        [Route("GetItemRateHistory/{customerId}/{itemId}/{saleTypeId}")]
        public List<Entities.SaleItemRateHistory> GetItemRateHistory(Int32 customerId, Int32 itemId, Int32 saleTypeId)
        {
            return _salesBill.GetItemRateHistory(customerId, itemId, saleTypeId);
        }
    }
}