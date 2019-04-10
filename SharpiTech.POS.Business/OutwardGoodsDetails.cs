using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class OutwardGoodsDetails
    {
        private readonly DataModel.OutwardGoodsDetails _outwardGoodsDetails;

        public OutwardGoodsDetails()
        {
            _outwardGoodsDetails = new DataModel.OutwardGoodsDetails();
        }

        public List<Entities.OutwardGoodsDetails> GetPkgSlipItems(Int32 pkgSlipId)
        {
            return _outwardGoodsDetails.GetPkgSlipItems(pkgSlipId);
        }

        public List<Entities.OutwardGoodsDetails> GetOutwardGoodsDetailsByOutwardId(Int32 outwardId)
        {
            return _outwardGoodsDetails.GetOutwardGoodsDetailsByOutwardId(outwardId);
        }

    }
}
