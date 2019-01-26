using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class CustomerAndTransporterMapping
    {
        private readonly DataModel.CustomerAndTransporterMapping _customerAndTransporterMapping;

        /// <summary>
        /// 
        /// </summary>
        public CustomerAndTransporterMapping()
        {
            _customerAndTransporterMapping = new DataModel.CustomerAndTransporterMapping();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Entities.CustomerAndTransporterMapping> GetAllCustomerAndTransporterMapping()
        {
            return _customerAndTransporterMapping.GetAllCustomerAndTransporterMapping();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerAddressId"></param>
        /// <returns></returns>
        public List<Entities.CustomerAndTransporterMapping> GetTransportersListByCustomerAddressId(Int32 customerAddressId)
        {
            return _customerAndTransporterMapping.GetTransportersListByCustomerAddressId(customerAddressId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ctm"></param>
        /// <returns></returns>
        public Int32 SaveCustomerAndTransporterMapping(Entities.CustomerAndTransporterMapping ctm)
        {
            return _customerAndTransporterMapping.SaveCustomerAndTransporterMapping(ctm);
        }

    }
}
