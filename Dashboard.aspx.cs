using System;
using System.Data;
using System.Data.SqlClient;

namespace study_tracker
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only logged-in users can see the dashboard
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblWelcome.Text = "Welcome back, " + Session["UserName"].ToString() + "!";
                LoadStats();
                LoadUpcomingTasks();
            }
        }

        // Count the tasks and work out the productivity percentage
        private void LoadStats()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            int total = 0;
            int completed = 0;

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM Tasks WHERE UserId = @UserId", con);
                cmdTotal.Parameters.AddWithValue("@UserId", userId);
                total = (int)cmdTotal.ExecuteScalar();

                SqlCommand cmdDone = new SqlCommand("SELECT COUNT(*) FROM Tasks WHERE UserId = @UserId AND Status = 'Completed'", con);
                cmdDone.Parameters.AddWithValue("@UserId", userId);
                completed = (int)cmdDone.ExecuteScalar();
            }

            int pending = total - completed;
            int productivity = (total == 0) ? 0 : (completed * 100 / total);

            lblTotal.Text = total.ToString();
            lblCompleted.Text = completed.ToString();
            lblPending.Text = pending.ToString();
            lblProductivity.Text = productivity + "%";

            // Update the green progress bar
            pbProductivity.Style["width"] = productivity + "%";
            pbProductivity.InnerText = productivity + "%";
        }

        // Show the next 5 pending tasks using a Repeater control
        private void LoadUpcomingTasks()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            DataTable dt = new DataTable();

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT TOP 5 Title, Subject, Priority, DueDate FROM Tasks " +
                    "WHERE UserId = @UserId AND Status = 'Pending' ORDER BY DueDate ASC", con);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                rptUpcoming.DataSource = dt;
                rptUpcoming.DataBind();
                pnlNoTasks.Visible = false;
            }
            else
            {
                // No tasks - show the friendly message instead
                rptUpcoming.DataSource = null;
                rptUpcoming.DataBind();
                pnlNoTasks.Visible = true;
            }
        }
    }
}
