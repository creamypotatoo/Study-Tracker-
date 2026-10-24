using System;

namespace study_tracker
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If the user is already logged in, take them straight to the dashboard
            if (Session["UserId"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }
    }
}
