using System;

namespace study_tracker
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Remove all the session values - this logs the user out
            Session.Clear();
            Session.Abandon();

            // Note: we keep the "Remember Me" cookie on purpose so the email is
            // still pre-filled next time. The cookie only stores the email address.

            Response.Redirect("Login.aspx");
        }
    }
}
