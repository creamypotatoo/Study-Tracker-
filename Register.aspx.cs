using System;
using System.Data.SqlClient;

namespace study_tracker
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // If already logged in there is no need to register again
            if (!IsPostBack && Session["UserId"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // The validation controls already checked the form, but double check on the server
            if (!Page.IsValid) return;

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                // Step 1: make sure the email is not already used
                SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email", con);
                check.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                int count = (int)check.ExecuteScalar();

                if (count > 0)
                {
                    lblMessage.Text = "This email is already registered. Please login instead.";
                    lblMessage.CssClass = "alert alert-danger d-block";
                    return;
                }

                // Step 2: insert the new user (new sign-ups are always normal 'User' role)
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Users (FullName, Email, Password, Role) VALUES (@FullName, @Email, @Password, 'User')", con);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                cmd.ExecuteNonQuery();
            }

            // Go to the login page and show a success message there
            Response.Redirect("Login.aspx?registered=1");
        }
    }
}
