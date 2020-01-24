using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEverNote.WebApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MyeverNote.BusinessLayer.Test test = new MyeverNote.BusinessLayer.Test();
            //test.InsertTest();
            //test.UpdateTest();
           // test.DeleteTest();
            
            return View();
        }
    }
}