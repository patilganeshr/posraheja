using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class SalesScheme
    {
        private readonly DataModel.SalesScheme _salesScheme;

        public SalesScheme()
        {
            _salesScheme = new DataModel.SalesScheme();
        }

        public List<Entities.SalesScheme> GetAllSalesSchemes()
        {
            return _salesScheme.GetAllSalesSchemes();
        }

        //public Entities.SalesScheme GetSalesSchemeDetails(Int32 itemId, string effectiveDate)
        //{
        //    return _salesScheme.GetSalesSchemeDetails(itemId, effectiveDate);
        //}

        public List<Entities.SalesScheme> GetSalesSchemeDetails(Int32 itemId, string effectiveDate)
        {
            return _salesScheme.GetSalesSchemeDetails(itemId, effectiveDate);
        }


        public Int32 SaveSalesScheme(Entities.SalesScheme salesScheme)
        {
            return _salesScheme.SaveSalesScheme(salesScheme);
        }
    }
}
