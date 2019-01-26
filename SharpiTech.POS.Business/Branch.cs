using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpiTech.POS.Business
{
    public class Branch
    {
        private readonly DataModel.Branch _branch;

        public Branch()
        {
            _branch = new DataModel.Branch();
        }

        public List<Entities.Branch> GetAllBranchNames()
        {
            return _branch.GetAllBranchNames();
        }

        public List<Entities.Branch> GetBranchesByCompanyId(Int32 companyId)
        {
            return _branch.GetBranchesByCompanyId(companyId);
        }
    }
}
