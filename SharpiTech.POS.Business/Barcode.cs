using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web;

namespace SharpiTech.POS.Business
{
    public class Barcode
    {
        private readonly DataModel.Barcode _barcode;

        public Barcode()
        {
            _barcode = new DataModel.Barcode();
        }

        public List<Entities.Barcode> GetVendors()
        {
            return _barcode.GetVendors();
        }

        public List<Entities.Barcode> GetItems(Int32 vendorId)
        {
            return _barcode.GetItems(vendorId);
        }

        public List<Entities.Barcode> GetItemsFromGoodsReceipt()
        {
            return _barcode.GetItemsFromGoodsReceipt();
        }

        public List<Entities.Barcode> GetItemsFromInwardOutward()
        {
            return _barcode.GetItemsFromInwardOutward();
        }

        public List<Entities.Barcode> SearchInwardNo(Int32 inwardNo)
        {
            return _barcode.SearchInwardNo(inwardNo);
        }

        public List<Entities.Barcode> GetItemsByInwardId(Int32 inwardId)
        {
            return _barcode.GetItemsByInwardId(inwardId);
        }

        public Int32 SaveBarcodeDetails(List<Entities.Barcode> barcode)
        {
            return _barcode.SaveBarcodeDetails(barcode);
        }

        public string PrintBarcode(string barcodeSize)
        {
            var report = new BuidReport();
            var reportEntity = new Entities.Report();

            //var serverPath = HttpContext.Current.Server.MapPath("../POS/");
            var serverPath = HttpContext.Current.Server.MapPath("/POS/");
            reportEntity.DirectoryPath = serverPath + "ApplicationFiles/Barcode/";

            if (barcodeSize.ToLower() == "large")
            {
                reportEntity.ReportPath = serverPath + "Reports/Barcode_6X3.5_cm.rpt";
            }
            else
            {
                reportEntity.ReportPath = serverPath + "Reports/Barcode_4X3.5_cm.rpt";
            }
            reportEntity.Parameters = null;
            reportEntity.FileStoragePath = reportEntity.DirectoryPath + "Barcode.pdf";

            return report.GenerateReport(reportEntity, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        }
    }
}
