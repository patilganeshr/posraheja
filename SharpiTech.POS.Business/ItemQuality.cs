using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class ItemQuality
    {
        private readonly DataModel.ItemQuality _itemQuality;

        public ItemQuality()
        {
            _itemQuality = new DataModel.ItemQuality();
        }

        public Int32 SaveItemQuality(Entities.ItemQuality itemQuality)
        {
            return _itemQuality.SaveItemQuality(itemQuality);
        }
            
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQuality"></param>
        /// <returns></returns>
        public bool DeleteItemQuality(Entities.ItemQuality itemQuality)
        {
            return _itemQuality.DeleteItemQuality(itemQuality);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.ItemQuality> GetAllItemQualities()
        {
            return _itemQuality.GetAllItemQualities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQualityId"></param>
        /// <returns></returns>
        public Entities.ItemQuality GetItemQualityById(Int32 itemQualityId)
        {
            return _itemQuality.GetItemQualityById(itemQualityId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemQualityName"></param>
        /// <returns></returns>
        public Entities.ItemQuality GetItemQualityByName(string itemQualityName)
        {
            return _itemQuality.GetItemQualityByName(itemQualityName);
        }


    }
}
