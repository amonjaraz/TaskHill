using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string TestText = "Welcome to TaskHill the task time tracking app!";
            return View((object)TestText);
        }
    }
}