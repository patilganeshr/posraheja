using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POS.Sales
{
    public partial class SalesBill: System.Web.UI.Page
    {
        protected void page_PreInit(object sender, EventArgs e)
        {
            Page p = this.Context.Handler as Page;
            if (p != null)
            {
                // set master page
                if (Request.Browser.IsMobileDevice)
                {
                    //p.MasterPageFile = "~/MasterPages/site.mobile.master";
                    p.MasterPageFile = "~/Site.Mobile.Master";
                }
                else
                {
                    //p.MasterPageFile = "~/MasterPages/site.master";
                    p.MasterPageFile = "~/Site.Master";
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}