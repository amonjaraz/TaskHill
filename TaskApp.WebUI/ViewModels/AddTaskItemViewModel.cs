using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace TaskApp.WebUI.ViewModels
{
    public class AddTaskItemViewModel
    {
        [Required]
        public string TaskItemDescription { get; set; }
    }
}