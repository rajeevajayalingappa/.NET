using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;


namespace MyMVC.Models
{
    public class StudentDetails
    {
        //GetData GTDB = new GetData();
        public DataSet ds1 { get; set; }
        public List<DataRow> Studentmodel { get; set; }
        //public List<StudentDetail> Studentmodel { get; set; }
        //public List<StudentDetail> Studentmodel()
        //{

        //}
    }
    public class StudentDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string Address { get; set; }
    }

    public class GetData:StudentDetails
    {
        public void Stu()
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
                //ds1 = ds;
                //string s = ds.GetXmlSchema();
                //var xml = ds.GetXml();
                //var dataSetObjects = Create<NewDataSet>(xml);
                //List<DataRow> list = ds.Tables[0].AsEnumerable().ToList();
                Studentmodel = ds.Tables[0].AsEnumerable().ToList();

            }
            catch (Exception ex)
            {
            }
        }

    }

    public class GetData1
    {
        string[] name;

        public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string sDir = "C:\\";

        public void DirSearch(string sDir)
        {
            //string sDir = "C:\\";

            try
            {
                foreach (string f in Directory.GetFiles(sDir, "*.rar"))
                {
                    name = f.Split('\\');
                    //files.Add(f);

                    dictionary.Add(f, name[name.Length - 1]);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt) { }
        }

        public DataTable Stu()
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
            catch (Exception ex) { }
            return ds.Tables[0];
        }

    }

}