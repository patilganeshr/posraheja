using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharpiTech.POS.Business
{
    public class TaxSlab
    {
        private readonly DataModel.TaxSlab _taxSlab;

        public TaxSlab()
        {
            _taxSlab = new DataModel.TaxSlab();
        }

        public List<Entities.TaxSlab> GetTaxSlabs()
        {
            return _taxSlab.GetTaxSlabs();
        }
    }
}
