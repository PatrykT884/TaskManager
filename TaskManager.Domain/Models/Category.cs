using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Models
{
    // Update the type of Tasks property from ICollection<Task> to ICollection<TaskItem>
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TaskItem> Tasks { get; set; }
    }

}
