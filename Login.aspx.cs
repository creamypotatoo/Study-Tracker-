using System;
using System.Data.SqlClient;
using System.Web;

namespace study_tracker
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // If they are already logged in, go to the dashboard
                if (Session["UserId"] != null)
                {
                    Response.Redirect("Dashboard.aspx");
                    return;
                }

                // Show a success message if they just registered
                if (Request.QueryString["registered"] == "1")
                {
                    lblMessage.Text = "Registration successful! Please login.";
                    lblMessage.CssClass = "alert alert-success d-block";
                }

                // Remember Me: if the cookie exists, pre-fill the email box
                if (Request.Cookies["StudyTrackerUser"] != null)
                {
                    HttpCookie cookie = Request.Cookies["StudyTrackerUser"];
                    txtEmail.Text = cookie.Values["Email"];
                    chkRemember.Checked = true;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT UserId, FullName, Role FROM Users WHERE Email = @Email AND Password = @Password", con);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    // Save the login info in Session (this is our login system)
                    Session["UserId"] = dr["UserId"].ToString();
                    Session["UserName"] = dr["FullName"].ToString();
                    Session["Role"] = dr["Role"].ToString();
                    string role = dr["Role"].ToString();
                    dr.Close();

                    // Remember Me cookie (stores the email so we can fill it in next time)
                    if (chkRemember.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("StudyTrackerUser");
                        cookie.Values["Email"] = txtEmail.Text.Trim();
                        cookie.Expires = DateTime.Now.AddDays(7);
                        Response.Cookies.Add(cookie);
                    }
                    else
                    {
                        // If the box is unticked, delete any old cookie
                        if (Request.Cookies["StudyTrackerUser"] != null)
                        {
                            HttpCookie cookie = new HttpCookie("StudyTrackerUser");
                            cookie.Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies.Add(cookie);
                        }
                    }

                    // Admins go to the admin area, normal users go to the dashboard
                    if (role == "Admin")
                        Response.Redirect("Admin/AdminDashboard.aspx");
                    else
                        Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    dr.Close();
                    lblMessage.Text = "Invalid email or password. Please try again.";
                    lblMessage.CssClass = "alert alert-danger d-block";
                }
            }
        }
    }
}
