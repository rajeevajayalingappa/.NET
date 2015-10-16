using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyMVC.Models;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

namespace MyMVC.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Home/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public List<String> files = new List<String>();
        //public Dictionary<string, string> dictionary = new Dictionary<string, string>();
        //string[] name;
        //GetData1 GD = new GetData1();

        public string Str()
        {
            string asdf = "My MVC Project Start";
            //return "My MVC Project Start";
            return HttpUtility.HtmlEncode(asdf);
        }

        public DataTable Dta()
        {
            GetData1 GTD = new GetData1();
            return GTD.Stu();
        }

        public ActionResult AboutUs()
        {
            //ViewBag.PageTitle = "Show this text into my MasterPage";
            return View();
        }

        public ActionResult Index()
        {
            //DirSearch(@"C:\\");
            //files.ToList();
            GetData1 GD1 = new GetData1();
            GD1.DirSearch(@"C:\");
            //StudentDetails _objuserloginmodel = new StudentDetails();
            //List<StudentDetail> _objStudent = new List<StudentDetail>();
            //_objStudent = GetStudentList();
            //_objuserloginmodel.Studentmodel = _objStudent;
            //var dr = _objuserloginmodel.Studentmodel;
            //return View(_objuserloginmodel);
            //var data = GD1.Stu();

            return View(GD1);
        }


        public List<StudentDetail> GetStudentList()
        {
            List<StudentDetail> objStudent = new List<StudentDetail>();
            ///*Create instance of entity model*/
            //NorthwindEntities objentity = new NorthwindEntities();
            ///*Getting data from database for user validation*/
            //var _objuserdetail = (from data in objentity.Students
            //                      select data);
            //foreach (var item in _objuserdetail)
            //{
            //    objStudent.Add(new StudentDetail { Id = item.Id, Name = item.Name, Section = item.Section, Class = item.Class, Address = item.Address });
            //}
            //return objStudent;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connect"].ConnectionString);
            SqlCommand cmd = null;
            SqlDataReader dr;
            try
            {
                if (con.State.ToString() == "Open")
                {
                    con.Close();
                }
                con.Open();
                cmd = new SqlCommand("SELECT [ID] FROM [Automation].[dbo].[tbl_UserMaster]", con);
                cmd.CommandType = CommandType.Text;
                dr = cmd.ExecuteReader();
                //int j = 0;

                StudentDetail Stu = new StudentDetail();
                //List<int> Li;

                //foreach (var item in dr)
                //{
                //    objStudent.Add(new StudentDetail { Id = Convert.ToInt16( item.ToString()) });
                //}
                while (dr.Read())
                {
                    //string asdf = dr.GetString(0);
                    objStudent.Add(new StudentDetail { Id = dr.GetInt32(0) });

                    //Stu.Id = Convert.ToInt16(dr.GetValue(j).ToString());
                    //Li.Add(Convert.ToInt16(dr.GetValue(j).ToString()));
                    //j += 1;
                }
                //_objuserloginmodel.Studentmodel.Add();

            }
            catch (Exception ex)
            {

            }
            return objStudent;
        }

        //public List<MyMVC.Models.Home.StudentDetail> GetStudentList()
        //{
        //    List<MyMVC.Models.Home.StudentDetail> objStudent = new List<MyMVC.Models.Home.StudentDetail>();
        //    /*Create instance of entity model*/
        //    NorthwindEntities objentity = new NorthwindEntities();
        //    /*Getting data from database for user validation*/
        //    var _objuserdetail = (from data in objentity.Students
        //                          select data);
        //    foreach (var item in _objuserdetail)
        //    {
        //        objStudent.Add(new StudentDetail { Id = item.Id, Name = item.Name, Section = item.Section, Class = item.Class, Address = item.Address });
        //    }
        //    return objStudent;
        //}


        [HttpPost]
        protected void lbl_Click()
        {

        }

    }
}
