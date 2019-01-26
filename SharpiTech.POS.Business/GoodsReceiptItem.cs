using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class GoodsReceiptItem
    {
        private readonly DataModel.GoodsReceiptItem _goodsReceiptItem;

        public GoodsReceiptItem()
        {
            _goodsReceiptItem = new DataModel.GoodsReceiptItem();
        }

        public List<Entities.GoodsReceiptItem> GetGoodsReceiptItemsByGoodsReceiptId(Int32 goodsReceiptId)
        {
            return _goodsReceiptItem.GetGoodsReceiptItemsByGoodsReceiptId(goodsReceiptId);
        }

        public Int32 SaveGoodsReceiptItem(Entities.GoodsReceiptItem goodsReceiptItem)
        {
            return _goodsReceiptItem.SaveGoodsReceiptItem(goodsReceiptItem);
        }

    }
}
