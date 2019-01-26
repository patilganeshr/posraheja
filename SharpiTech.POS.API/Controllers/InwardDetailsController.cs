using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class InwardDetailsController : ApiController
    {
        private readonly Business.InwardDetails _inwardDetails;

        public InwardDetailsController()
        {
            _inwardDetails = new Business.InwardDetails();
        }

        [HttpGet]
        [Route("CheckInwardExistsInSalesBill/{inwardId}")]
        public bool CheckInwardExistsInSalesBill(Int32 inwardId)
        {
            return _inwardDetails.CheckInwardExistsInSalesBill(inwardId);
        }

        /// <summary>
        /// Return the list of inward details. 
        /// </summary>
        /// <returns>Return collections of Inward list.</returns>
        [Route("GetAllInwardDetails")]
        public List<Entities.InwardDetails> GetAllInwardDetails()
        {
            return _inwardDetails.GetAllInwardDetails();
        }

        /// <summary>
        /// Get Reference No.'s from Goods Receipt
        /// </summary>
        /// <returns>Return as List</returns>
        [Route("GetReferenceNosFromGoodsReceipt")]
        public List<Entities.InwardDetails> GetReferenceNosFromGoodsReceipt()
        {
            return _inwardDetails.GetReferenceNosFromGoodsReceipt();
        }

        /// <summary>
        /// Get Reference No.'s from Outward
        /// </summary>
        /// <returns>Return as List</returns>
        [Route("GetReferenceNosFromOutwards")]
        public List<Entities.InwardDetails> GetReferenceNosFromOutwards()
        {
            return _inwardDetails.GetReferenceNosFromOutwards();
        }

        /// <summary>
        /// Get Reference No.'s from Job Work
        /// </summary>
        /// <returns>Return as List</returns>
        [Route("GetReferenceNosFromJobWork")]
        public List<Entities.InwardDetails> GetReferenceNosFromJobWork()
        {
            return _inwardDetails.GetReferenceNosFromJobWork();
        }

        [Route("GetReferenceNoFromInward/{inwardId}")]
        public List<Entities.InwardDetails> GetReferenceNoFromInward(Int32 inwardId)
        {
            return _inwardDetails.GetReferenceNoFromInward(inwardId);
        }

        /// <summary>
        /// Get Reference No. Details from Goods Rececipt
        /// </summary>
        /// <param name="goodsReceiptId">Required GoodsReceiptId as an integer parameter.</param>
        /// <returns></returns>
        [Route("GetReferenceNoDetailsByGoodsReceiptId/{goodsReceiptId}")]
        public Entities.InwardDetails GetReferenceNoDetailsByGoodsReceiptId(Int32 goodsReceiptId)
        {
            return _inwardDetails.GetReferenceNoDetailsByGoodsReceiptId(goodsReceiptId);
        }

        /// <summary>
        /// Get Reference No. details from Outward
        /// </summary>
        /// <param name="outwardId">Required OutwardId as an integer parameter.</param>
        /// <returns></returns>
        [Route("GetReferenceNoDetailsByOutwardId/{outwardId}")]
        public Entities.InwardDetails GetReferenceNoDetailsByOutwardId(Int32 outwardId)
        {
            return _inwardDetails.GetReferenceNoDetailsByOutwardId(outwardId);
        }

        /// <summary>
        /// Get Inward Goods Details by GoodsReceiptId.
        /// </summary>
        /// <param name="goodsReceiptId">Required GoodsReceiptId as an integer parameter.</param>
        /// <returns></returns>
        [Route("GetInwardGoodsDetailsByGoodsReceiptId/{goodsReceiptId}")]
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByGoodsReceiptId(Int32 goodsReceiptId)
        {
            return _inwardDetails.GetInwardGoodsDetailsByGoodsReceiptId(goodsReceiptId);
        }

        /// <summary>
        /// Get Inward Goods Details by OutwardId.
        /// </summary>
        /// <param name="outwardId">Required OutwardId as an integer parameter.</param>
        /// <returns></returns>
        [Route("GetInwardGoodsDetailsByOutwardId/{outwardId}")]
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByOutwardId(Int32 outwardId)
        {
            return _inwardDetails.GetInwardGoodsDetailsByOutwardId(outwardId);
        }

        /// <summary>
        /// Get Inward Goods Details by OutwardId.
        /// </summary>
        /// <param name="jobWorkId">Required JobWorkId as an integer parameter.</param>
        /// <returns></returns>
        [Route("GetInwardGoodsDetailsByJobWorkId/{jobWorkId}")]
        public List<Entities.InwardGoodsDetails> GetInwardGoodsDetailsByJobWorkId(Int32 jobWorkId)
        {
            return _inwardDetails.GetInwardGoodsDetailsByJobWorkId(jobWorkId);
        }

        /// <summary>
        /// Save the Inward Details.
        /// </summary>
        /// <param name="inwardDetails">An object of a InwardDetails entity class.</param>
        /// <returns>Return an integer value as last identity record.</returns>
        [HttpPost]
        [Route("SaveInwardDetails")]
        public Int32 SaveInwardDetails(List<Entities.InwardDetails> inwardDetails)
        {
            return _inwardDetails.SaveInwardDetails(inwardDetails);
        }

    }
}
