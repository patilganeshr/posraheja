using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class InwardDetails
    {
        private readonly DataModel.InwardDetails _inwardDetails;

        public InwardDetails()
        {
            _inwardDetails = new DataModel.InwardDetails();
        }

        public bool CheckInwardExistsInSalesBill(Int32 inwardId)
        {
            return _inwardDetails.CheckInwardExistsInSalesBill(inwardId);
        }
        /// <summary>
        /// Return the list of inward details. 
        /// </summary>
        /// <returns>Return collections of Inward list.</returns>
        public List<Entities.InwardDetails> GetAllInwardDetails()
        {
            return _inwardDetails.GetAllInwardDetails();
        }

        /// <summary>
        /// Get Reference No.'s from Goods Receipt
        /// </summary>
        /// <returns>Return as List</returns>
        public List<Entities.InwardDetails> GetReferenceNosFromGoodsReceipt()
        {
            return _inwardDetails.GetReferenceNosFromGoodsReceipt();
        }

        /// <summary>
        /// Get Reference No.'s from Outward
        /// </summary>
        /// <returns>Return as List</returns>
        public List<Entities.InwardDetails> GetReferenceNosFromOutwards()
        {
            return _inwardDetails.GetReferenceNosFromOutwards();
        }

        /// <summary>
        /// Get Reference No.'s from Job Work
        /// </summary>
        /// <returns>Return as List</returns>
        public List<Entities.InwardDetails> GetReferenceNosFromJobWork()
        {
            return _inwardDetails.GetReferenceNosFromJobWork();
        }

        public List<Entities.InwardDetails> GetReferenceNoFromInward(Int32 inwardId)
        {
            return _inwardDetails.GetReferenceNoFromInward(inwardId);
        }

        /// <summary>
        /// Get Reference No. Details from Goods Rececipt
        /// </summary>
        /// <param name="goodsReceiptId">Required GoodsReceiptId as an integer parameter.</param>
        /// <returns></returns>
        public Entities.InwardDetails GetReferenceNoDetailsByGoodsReceiptId(Int32 goodsReceiptId)
        {
            return _inwardDetails.GetReferenceNoDetailsByGoodsReceiptId(goodsReceiptId);
        }

        /// <summary>
        /// Get Reference No. details from Outward
        /// </summary>
        /// <param name="outwardId">Required OutwardId as an integer parameter.</param>
        /// <returns></returns>
        public Entities.InwardDetails GetReferenceNoDetailsByOutwardId(Int32 outwardId)
        {
            return _inwardDetails.GetReferenceNoDetailsByOutwardId(outwardId);
        }

        /// <summary>
        /// Get Inward Goods Details by GoodsReceiptId.
        /// </summary>
        /// <param name="goodsReceiptId">Required GoodsReceiptId as an integer parameter.</param>
        /// <returns></returns>
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByGoodsReceiptId(Int32 goodsReceiptId)
        {
            return _inwardDetails.GetInwardGoodsDetailsByGoodsReceiptId(goodsReceiptId);
        }

        /// <summary>
        /// Get Inward Goods Details by OutwardId.
        /// </summary>
        /// <param name="outwardId">Required OutwardId as an integer parameter.</param>
        /// <returns></returns>
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByOutwardId(Int32 outwardId)
        {
            return _inwardDetails.GetInwardGoodsDetailsByOutwardId(outwardId);
        }

        /// <summary>
        /// Get Inward Goods Details by OutwardId.
        /// </summary>
        /// <param name="jobWorkId">Required JobWorkId as an integer parameter.</param>
        /// <returns></returns>
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByJobWorkId(Int32 jobWorkId)
        {
            return _inwardDetails.GetInwardGoodsDetailsByJobWorkId(jobWorkId);
        }

        /// <summary>
        /// Save the Inward Details.
        /// </summary>
        /// <param name="inwardDetails">An object of a InwardDetails entity class.</param>
        /// <returns>Return an integer value as last identity record.</returns>
        public Int32 SaveInwardDetails(List<Entities.InwardDetails> inwardDetails)
        {
            return _inwardDetails.SaveInwardDetails(inwardDetails);
        }
    }
}
