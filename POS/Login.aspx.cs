using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using entities = SharpiTech.POS.Entities;
using business = SharpiTech.POS.Business;

namespace POS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                username.Value = "";
                password.Value = "";

                username.Focus();
            }

        }

        protected void ShowMessage(string message)
        {
            var sb = new StringBuilder();

            sb.Append("<script type='text/javascript'>");
            //sb.Append("alert('" + message + "');");
            sb.Append("swal('Error!!!', '" + message + "', 'warning');");
            sb.Append("</script>");

            //Response.Write(sb.ToString());

            alertMessage.Text = sb.ToString();

            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            if (username.Value.Trim() == string.Empty)
            {
                ShowMessage("User Name field should not be left blank.");
                username.Focus();
                return;
            }
            else if (password.Value.Trim() == string.Empty)
            {
                ShowMessage("Password field should not be left blank.");
                password.Focus();
                return;
            }

            entities.User user = new entities.User();
            business.User _user = new business.User();

            user = _user.GetUserDetails(username.Value, password.Value);

            if (user != null)
            {
                if (user.UserId == 0)
                {
                    ShowMessage("User Not Found.");
                    username.Focus();
                    return;
                }
                else
                {
                    Response.Redirect("/pos/dashboard.aspx", false);
                }
            }
        }
    }
}