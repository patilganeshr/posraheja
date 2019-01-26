using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SharpiTech.POS.API.Controllers
{
    public class BranchController : ApiController
    {
        private readonly Business.Branch _branch;

        public BranchController()
        {
            _branch = new Business.Branch();
        }

        [Route("GetAllBranchNames")]
        public List<Entities.Branch> GetAllBranchNames()
        {
            return _branch.GetAllBranchNames();
        }

        [Route("GetBranchesByCompanyId/{companyId}")]
        public List<Entities.Branch> GetBranchesByCompanyId(Int32 companyId)
        {
            return _branch.GetBranchesByCompanyId(companyId);
        }
    }
}
