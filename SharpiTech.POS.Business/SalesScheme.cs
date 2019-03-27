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

        public Int32 SaveSalesScheme(Entities.SalesScheme salesScheme)
        {
            return _salesScheme.SaveSalesScheme(salesScheme);
        }
    }
}
