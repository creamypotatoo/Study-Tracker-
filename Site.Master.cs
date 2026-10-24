using System;

namespace study_tracker
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Show the current year in the footer
            litYear.Text = DateTime.Now.Year.ToString();

            // Is somebody logged in?  (we store the user id in Session when they log in)
            bool loggedIn = Session["UserId"] != null;

            // Links that only logged-in users should see
            liDashboard.Visible = loggedIn;
            liTasks.Visible = loggedIn;
            liProfile.Visible = loggedIn;
            liUser.Visible = loggedIn;
            liLogout.Visible = loggedIn;

            // Links for guests (not logged in)
            liLogin.Visible = !loggedIn;
            liRegister.Visible = !loggedIn;

            // The Admin link is only for admin users
            bool isAdmin = loggedIn && Session["Role"] != null && Session["Role"].ToString() == "Admin";
            liAdmin.Visible = isAdmin;

            // Greeting in the navbar
            if (loggedIn)
            {
                litUser.Text = "Hi, " + Session["UserName"].ToString();
            }
        }
    }
}
