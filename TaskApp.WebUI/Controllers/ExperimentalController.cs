using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskApp.Domain.Concrete;
using TaskApp.Domain.Abstract;

namespace TaskApp.WebUI.Controllers
{
    public class ExperimentalController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public ExperimentalController(IUnitOfWork unitOfWorkParam)
        {
            _unitOfWork = unitOfWorkParam;
        }

        // GET: Experimental
        public ActionResult Index()
        {
            ViewBag.Content = "Experiment Index Action";
            return View(_unitOfWork.Tasks.GetAllTasks());
        }
    }
}