using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class InwardGoodsDetails
    {
        private readonly DataModel.InwardGoodsDetails _inwardGoodsDetails;

        public InwardGoodsDetails()
        {
            _inwardGoodsDetails = new DataModel.InwardGoodsDetails();
        }

        /// <summary>
        /// Return the list of Inward Goods Details.
        /// </summary>
        /// <param name="inwardId">Required InwardId as an integer parameter.</param>
        /// <returns>Return the collections of Inward Goods Details.</returns>
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByInwardId(Int32 inwardId)
        {
            return _inwardGoodsDetails.GetInwardGoodsDetailsByInwardId(inwardId);
        }
    }
}
