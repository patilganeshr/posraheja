using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class SalesSchemeRegister
    {
        private readonly DataModel.SalesSchemeRegister _salesSchemeRegister;

        public SalesSchemeRegister()
        {
            _salesSchemeRegister = new DataModel.SalesSchemeRegister();
        }

        public List<Entities.SalesSchemeRegister> GetSalesSchemesRegister()
        {
            return _salesSchemeRegister.GetSalesSchemesRegister();
        }
        

    }
}
