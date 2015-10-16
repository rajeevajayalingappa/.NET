using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMVC.Models
{
    public class Default
    {
        int Ret = 0;
        public string name { get; set; }

        public int SaveData(string name)
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
                cmd = new SqlCommand("insert into [Automation].[dbo].[tblUsers] values ('" + name.ToString() + "')", con);
                cmd.CommandType = CommandType.Text;
                Ret = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            return Ret;
        }

        public DataTable GetData()
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
                cmd = new SqlCommand("SELECT [vName] FROM [Automation].[dbo].[tblUsers]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex) { }
            return ds.Tables[0];
        }

    }
}