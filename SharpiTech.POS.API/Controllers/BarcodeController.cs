using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class BarcodeController : ApiController
    {
        private readonly Business.Barcode _barcode;

        public BarcodeController()
        {
            _barcode = new Business.Barcode();
        }

        [Route("GetVendors")]
        public List<Entities.Barcode> GetVendors()
        {
            return _barcode.GetVendors();
        }

        [Route("GetItems/{vendorid}")]
        public List<Entities.Barcode> GetItems(Int32 vendorId)
        {
            return _barcode.GetItems(vendorId);
        }

        [Route("GetItemsFromGoodsReceipt")]
        public List<Entities.Barcode> GetItemsFromGoodsReceipt()
        {
            return _barcode.GetItemsFromGoodsReceipt();
        }

        [Route("GetItemsFromInwardOutward")]
        public List<Entities.Barcode> GetItemsFromInwardOutward()
        {
            return _barcode.GetItemsFromInwardOutward();
        }

        [HttpGet]
        [Route("SearchInwardNo/{inwardNo}")]
        public List<Entities.Barcode> SearchInwardNo(Int32 inwardNo)
        {
            return _barcode.SearchInwardNo(inwardNo);
        }

        [Route("GetItemsByInwardId/{inwardId}")]
        public List<Entities.Barcode> GetItemsByInwardId(Int32 inwardId)
        {
            return _barcode.GetItemsByInwardId(inwardId);
        }

        [HttpPost]
        [Route("SaveBarcodeDetails")]
        public Int32 SaveBarcodeDetails(List<Entities.Barcode> barcode)
        {
            return _barcode.SaveBarcodeDetails(barcode);
        }
        
        [HttpGet]
        [Route("PrintBarcode/{barcodeSize}")]
        public string PrintBarcode(string barcodeSize)
        {
            return _barcode.PrintBarcode(barcodeSize);
        }

    }
}
