using System;
using System.Data.SqlClient;

namespace study_tracker
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Must be logged in
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadProfile();
            }
        }

        private void LoadProfile()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT FullName, Email, CreatedDate FROM Users WHERE UserId = @UserId", con);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtFullName.Text = dr["FullName"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                    lblMemberSince.Text = Convert.ToDateTime(dr["CreatedDate"]).ToString("dd MMM yyyy");
                }
                dr.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            int userId = Convert.ToInt32(Session["UserId"]);

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd;

                if (string.IsNullOrEmpty(txtNewPassword.Text))
                {
                    // Only update the name
                    cmd = new SqlCommand("UPDATE Users SET FullName = @FullName WHERE UserId = @UserId", con);
                }
                else
                {
                    // Update the name and the password
                    cmd = new SqlCommand("UPDATE Users SET FullName = @FullName, Password = @Password WHERE UserId = @UserId", con);
                    cmd.Parameters.AddWithValue("@Password", txtNewPassword.Text);
                }

                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.ExecuteNonQuery();
            }

            // Update the name shown in the navbar straight away
            Session["UserName"] = txtFullName.Text.Trim();

            // Clear the password boxes
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";

            lblMessage.Text = "Your profile has been updated successfully.";
            lblMessage.CssClass = "alert alert-success d-block";
        }
    }
}
