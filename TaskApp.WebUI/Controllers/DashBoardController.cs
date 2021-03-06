﻿using System;
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

        [HttpPost] 
        public ActionResult List(int TaskItemId, int Time)
        {
            if (ModelState.IsValid)
            {
                TaskItem obj = _unitOfWork.Tasks.Get(TaskItemId);
                if (obj != null)
                {
                    obj.Time = Time;
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
                TaskItem newTaskItem = new TaskItem { Description = item.TaskItemDescription};
                _unitOfWork.Tasks.Add(newTaskItem);
                _unitOfWork.Complete();
                return RedirectToAction("List");
            }
            else return View();
        }
    }
}