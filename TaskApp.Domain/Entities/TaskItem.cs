using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApp.Domain.Entities
{
    public class TaskItem
    {
        [Key]
        public int TaskItemId { get; set; }
        [StringLength(50)]
        [Required]
        public string Description { get; set; }
        [Required]
        public int Time { get; set; }
        //public DateTime DateCreated { get; set; }
        public int Level { get; set; }
        
        public bool Subdivided { get; set; }
        public int? ParentId { get; set; }
        public int CategoryId { get; set; }

        public TaskItem()
        {

        }
    }
}
