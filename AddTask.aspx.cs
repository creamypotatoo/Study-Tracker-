using System;
using System.Data.SqlClient;

namespace study_tracker
{
    public partial class AddTask : System.Web.UI.Page
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
                // If an "id" was passed in the URL, we are editing an existing task
                if (Request.QueryString["id"] != null)
                {
                    lblHeading.Text = "Edit Task";
                    btnSave.Text = "Update Task";
                    LoadTask(Convert.ToInt32(Request.QueryString["id"]));
                }
                else
                {
                    lblHeading.Text = "Add New Task";
                    btnSave.Text = "Save Task";
                }
            }
        }

        // Fill the form with the existing task details (for editing)
        private void LoadTask(int taskId)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT Title, Subject, Description, Priority, DueDate, Status FROM Tasks WHERE TaskId = @TaskId AND UserId = @UserId", con);
                cmd.Parameters.AddWithValue("@TaskId", taskId);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtTitle.Text = dr["Title"].ToString();
                    txtSubject.Text = dr["Subject"].ToString();
                    txtDescription.Text = dr["Description"].ToString();
                    ddlPriority.SelectedValue = dr["Priority"].ToString();
                    ddlStatus.SelectedValue = dr["Status"].ToString();
                    if (dr["DueDate"] != DBNull.Value)
                    {
                        // The HTML date box needs the yyyy-MM-dd format
                        txtDueDate.Text = Convert.ToDateTime(dr["DueDate"]).ToString("yyyy-MM-dd");
                    }
                    dr.Close();
                }
                else
                {
                    // Task not found (or it belongs to someone else) - go back to the list
                    dr.Close();
                    Response.Redirect("Tasks.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            int userId = Convert.ToInt32(Session["UserId"]);

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd;

                if (Request.QueryString["id"] != null)
                {
                    // UPDATE the existing task
                    cmd = new SqlCommand(
                        "UPDATE Tasks SET Title=@Title, Subject=@Subject, Description=@Description, " +
                        "Priority=@Priority, DueDate=@DueDate, Status=@Status " +
                        "WHERE TaskId=@TaskId AND UserId=@UserId", con);
                    cmd.Parameters.AddWithValue("@TaskId", Convert.ToInt32(Request.QueryString["id"]));
                }
                else
                {
                    // INSERT a brand new task
                    cmd = new SqlCommand(
                        "INSERT INTO Tasks (UserId, Title, Subject, Description, Priority, DueDate, Status) " +
                        "VALUES (@UserId, @Title, @Subject, @Description, @Priority, @DueDate, @Status)", con);
                }

                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Subject", txtSubject.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@Priority", ddlPriority.SelectedValue);
                cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);

                // The due date is optional - store NULL if it was left empty
                if (string.IsNullOrEmpty(txtDueDate.Text))
                    cmd.Parameters.AddWithValue("@DueDate", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@DueDate", Convert.ToDateTime(txtDueDate.Text));

                cmd.ExecuteNonQuery();
            }

            Response.Redirect("Tasks.aspx");
        }
    }
}
