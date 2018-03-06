using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskApp.Domain.Concrete;
using TaskApp.Domain.Entities;
using TaskApp.Domain.Abstract;
using TaskApp.WebUI.ViewModels;

namespace TaskApp.WebUI.Controllers
{
    public class DashBoardController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public DashBoardController(IUnitOfWork unitOfWorkParam)
        {
            _unitOfWork = unitOfWorkParam;
        }

        public ActionResult Index()
        {
            string strg = "Index Dashboard Controller";
            
            return View((object)strg);
        }

        // GET: DashBoard
        public ActionResult List()
        {
            return View(_unitOfWork.Tasks.GetAllTasks());
        }

        //[HttpPost] //Not using Model Binding
        //public RedirectToRouteResult List(int TaskItemId, int Time)
        //{
        //    TaskItem obj =  _unitOfWork.Tasks.Get(TaskItemId);
        //    if (obj != null) {
        //        obj.Time = Time;
        //        _unitOfWork.Complete();
        //    }


        //    return RedirectToAction("List");
        //}

        [HttpPost] //Using model Binding
        public ActionResult List(TaskItem item)
        {
            if (ModelState.IsValid)
            {
                TaskItem obj = _unitOfWork.Tasks.Get(item.TaskItemId);
                if (obj != null)
                {
                    obj.Time = item.Time;
                    _unitOfWork.Tasks.UpdateParentTasks(item,true);
                    _unitOfWork.Complete();
                }
                return RedirectToAction("List");
            }
            else
            {
                return View("List", _unitOfWork.Tasks.GetAllTasks());
            }

        }

        [HttpPost]
        public ActionResult Delete(TaskItem item)
        {
            TaskItem obj = _unitOfWork.Tasks.Get(item.TaskItemId);
            if (obj != null)
            {
                _unitOfWork.Tasks.Remove(obj);
                _unitOfWork.Tasks.UpdateParentTasks(obj, false);
                _unitOfWork.Complete();
            }
            return RedirectToAction("List");
        }

        public ViewResult AddTaskItem()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddTaskItem(AddTaskItemViewModel item)
        {
            if (ModelState.IsValid)
            {
                TaskItem newTaskItem = new TaskItem { Description = item.TaskItemDescription, ParentId = item.TaskItemParentId };
                _unitOfWork.Tasks.Add(newTaskItem);
                _unitOfWork.Complete();
                return RedirectToAction("List");
            }
            else return View();

            
        }

        public ActionResult TestTreeList()
        {
            TaskTree parent1 = new TaskTree { Name = "Parent 1" };
            TaskTree child1p1 = new TaskTree { Name = "Child 1 parent 1" };
            TaskTree child1c1 = new TaskTree { Name = "Child 2 parent 1" };
            TaskTree parent2 = new TaskTree { Name = "Parent 2" };
            TaskTree child1p2 = new TaskTree { Name = "Child 1 parent 2" };

            parent1.Children = new List<TaskTree>();
            //child1p1.Children = new List<TaskTree>();
            //child1p1.Children.Add(child1c1);
            parent1.Children.Add(child1p1);
            parent1.Children.Add(child1c1);

            parent2.Children = new List<TaskTree>();
            parent2.Children.Add(child1p2);

            List<TaskTree> tree = new List<TaskTree>();
            tree.Add(parent1);
            tree.Add(parent2);
            return View(tree);
        }
    }
}