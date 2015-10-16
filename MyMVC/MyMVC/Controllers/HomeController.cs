using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            ViewBag.Message = "Your Application description page !";
            return View();
        }

        public StringBuilder About()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table>");
            for (int i = 0; i < 10; i++)
            {
                sb.AppendLine("<tr><td>");
                sb.AppendLine(i.ToString() + ".) Welcome to About us Page");
                sb.AppendLine("</td></tr>");
            }
            sb.AppendLine("</table>");
            return sb;
        }
    }
}
