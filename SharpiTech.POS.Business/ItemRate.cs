using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class ItemRate
    {
        private readonly DataModel.ItemRate _itemRate;

        public ItemRate()
        {
            _itemRate = new DataModel.ItemRate();
        }

        public List<Entities.ItemRate> GetAllItemsRates()
        {
            return _itemRate.GetAllItemsRates();
        }

        public List<Entities.ItemRate> GetItemsRatesByItemId(Int32 itemId)
        {
            return _itemRate.GetItemsRatesByItemId(itemId);
        }

        public Entities.ItemRate GetItemRateByItemRateId(Int32 itemRateId)
        {
            return _itemRate.GetItemRateByItemRateId(itemRateId);
        }

        public Int32 SaveItemRate(List<Entities.ItemRate> itemRates)
        {
            return _itemRate.SaveItemRate(itemRates);
        }

    }
}
