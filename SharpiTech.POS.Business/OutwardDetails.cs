using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class OutwardDetails
    {
        private readonly DataModel.OutwardDetails _outwardDetails;
        private readonly DataModel.OutwardGoodsDetails _outwardGoodsDetails;

        public OutwardDetails()
        {
            _outwardDetails = new DataModel.OutwardDetails();
            _outwardGoodsDetails = new DataModel.OutwardGoodsDetails();
        }

        public List<Entities.OutwardDetails> GetAllOutwardDetails()
        {
            return _outwardDetails.GetAllOutwardDetails();
        }

        public List<Entities.OutwardDetails> GetBaleNos()
        {
            return _outwardDetails.GetBaleNos();
        }
        public List<Entities.OutwardDetails> GetPendingPkgSlipNos()
        {
            return _outwardDetails.GetPendingPkgSlipNos();
        }

        public Entities.OutwardDetails GetPkgSlipAdditionalDetails(Int32 pkgSlipId)
        {
            return _outwardDetails.GetPkgSlipAdditionalDetails(pkgSlipId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outwardDetails"></param>
        /// <returns></returns>
        public Int32 SaveOutwardDetails(Entities.OutwardDetails outwardDetails)
        {
            return _outwardDetails.SaveOutwardDetails(outwardDetails);
        }

    }
}
