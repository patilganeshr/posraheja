using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class ItemRateRegister
    {
        private readonly DataModel.ItemRateRegister _itemRateRegister;

        public ItemRateRegister()
        {
            _itemRateRegister = new DataModel.ItemRateRegister();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.ItemRateRegister> GetItemRateRegister()
        {
            return _itemRateRegister.GetItemRateRegister();
        }

        public List<Entities.ItemRateRegister> GetItemRateRegisterByWorkingPeriod(Int32 workingPeriodId)
        {
            return _itemRateRegister.GetItemRateRegisterByWorkingPeriod(workingPeriodId);
        }

        public List<Entities.ItemMargin> GetItemMarginByCategorywiseQualitywiseCostwise()
        {
            return _itemRateRegister.GetItemMarginByCategorywiseQualitywiseCostwise();
        }

    }
}
