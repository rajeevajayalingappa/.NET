using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMVC.Models;

namespace MyMVC.Controllers
{
    public class NewController : Controller
    {
        //
        // GET: /New/

        public ActionResult Index()
        {
            GetData1 obj = new GetData1();            
            return View(obj);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Default obj = new Default();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Create(Default obj)
        {
            Default df = new Default();
            if (df.SaveData(obj.name) > 0)
            {
                return Redirect("/New/Create");
            }
            else
            {
                return Redirect("/New/Create");
            }
            
        }

        public string NewDisplay()
        {
            return "Hi! Thanks for visiting the WbSite.";
        }
    }
}
