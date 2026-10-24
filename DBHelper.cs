using System.Configuration;
using System.Data.SqlClient;

namespace study_tracker
{
    /// <summary>
    /// Small helper class so we don't repeat the connection string in every page.
    /// Usage:  using (SqlConnection con = DBHelper.GetConnection()) { ... }
    /// </summary>
    public class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            // Read the connection string from Web.config
            string cs = ConfigurationManager.ConnectionStrings["StudyTrackerConnection"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}
