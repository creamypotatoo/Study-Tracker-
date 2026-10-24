using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace study_tracker
{
    public partial class Tasks : System.Web.UI.Page
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
                LoadTasks();
            }
        }

        private void LoadTasks()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            string filter = ddlFilter.SelectedValue;

            // Build the query depending on the filter dropdown
            string sql = "SELECT TaskId, Title, Subject, Priority, DueDate, Status FROM Tasks WHERE UserId = @UserId";
            if (filter == "Pending") sql += " AND Status = 'Pending'";
            else if (filter == "Completed") sql += " AND Status = 'Completed'";
            sql += " ORDER BY DueDate ASC";

            DataTable dt = new DataTable();
            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UserId", userId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            gvTasks.DataSource = dt;
            gvTasks.DataBind();
        }

        protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvTasks.PageIndex = 0;
            LoadTasks();
        }

        protected void gvTasks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTasks.PageIndex = e.NewPageIndex;
            LoadTasks();
        }

        protected void gvTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // The TaskId was passed through the CommandArgument
            if (e.CommandName == "MarkComplete" || e.CommandName == "DeleteTask")
            {
                int taskId = Convert.ToInt32(e.CommandArgument);
                int userId = Convert.ToInt32(Session["UserId"]);

                using (SqlConnection con = DBHelper.GetConnection())
                {
                    con.Open();
                    SqlCommand cmd;
                    if (e.CommandName == "MarkComplete")
                    {
                        // The "AND UserId" part makes sure a user can only change their own tasks
                        cmd = new SqlCommand("UPDATE Tasks SET Status = 'Completed' WHERE TaskId = @TaskId AND UserId = @UserId", con);
                    }
                    else
                    {
                        cmd = new SqlCommand("DELETE FROM Tasks WHERE TaskId = @TaskId AND UserId = @UserId", con);
                    }
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.ExecuteNonQuery();
                }

                LoadTasks();
            }
        }
    }
}
