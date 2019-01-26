using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class SaleQtyReport
    {
        private readonly DataModel.SaleQtyReport _saleQtyReport;

        public SaleQtyReport()
        {
            _saleQtyReport = new DataModel.SaleQtyReport();
        }

        public List<Entities.SaleQtyReport> GetSaleQtyOfAllItemCategories()
        {
            return _saleQtyReport.GetSaleQtyOfAllItemCategories();
        }

        public List<Entities.SaleQtyReport> GetSaleQtyOfAllItemCategoriesAndItemQualities()
        {
            return _saleQtyReport.GetSaleQtyOfAllItemCategoriesAndItemQualities();
        }

        public List<Entities.SaleQtyReport> GetSaleQtyOfAllItemCategoriesItemQualitiesAndItem()
        {
            return _saleQtyReport.GetSaleQtyOfAllItemCategoriesItemQualitiesAndItem();
        }

    }
}
