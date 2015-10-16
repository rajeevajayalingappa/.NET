using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyMVC
{
    public class GetDataFromDB
    {        
        public DataSet SM()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ConnectionString);
            SqlCommand cmd = null;
            DataSet ds = new DataSet();
            try
            {
                if (con.State.ToString() == "Open")
                {
                    con.Close();
                }
                con.Open();
                cmd = new SqlCommand("SELECT [ID] FROM [Automation].[dbo].[tbl_UserMaster]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            return ds;
        }
    }
}