﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain.Entities;

namespace TaskApp.WebUI.ViewModels
{
    public class ListViewModel
    {

    }

    public class TaskTree
    {
        public string Name { get; set; }
        public List<TaskTree> Children { get; set; }
    }
}