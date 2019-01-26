using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class SalesBillItem
    {
        private readonly DataModel.SalesBillItem _salesBillItem;

        public SalesBillItem()
        {
            _salesBillItem = new DataModel.SalesBillItem();
        }

        public List<Entities.SalesBillItem> GetSalesBillItemsBySalesBillId(Int32 salesBillId)
        {
            return _salesBillItem.GetSalesBillItemsBySalesBillId(salesBillId);
        }

        public List<Entities.SalesBillItem> SearchSaleItemByItemName(string itemName)
        {
            return _salesBillItem.SearchSaleItemByItemName(itemName);
        }

        public Int32 SaveSalesBillItem(Entities.SalesBillItem salesBillItem)
        {
            return _salesBillItem.SaveSalesBillItem(salesBillItem);
        }
        
    }
}
