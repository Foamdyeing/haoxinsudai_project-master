using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HRKJ.DAL
{
    public static class SqlHelper
    {
        private static readonly string constr = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;


        public static int ExecuteNonQuery(string sql, SqlParameter[] param)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();

                    if (param != null)
                        cmd.Parameters.AddRange(param);
                    return cmd.ExecuteNonQuery();
                }
            }

        }

        public static DataTable Query(string sql, SqlParameter[] param)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, constr))
            {
                if (param != null)
                    sda.SelectCommand.Parameters.AddRange(param);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                return dt;
            }
        }
    }
}