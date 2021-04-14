using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Task = Model.Task;

namespace BLL.Validators
{
  public  class TaskValidator
    {
        public void ValidateTask(Task task)
        {
            if (string.IsNullOrEmpty(task.Description))
            {
                throw new InvalidDataException("Task must have a description");
            }

            if (task.Description.Length < 5)
            {
                throw new InvalidDataException("Task description has to be at least 5 characters long");
            }
            // Id is an int and int is never null 
            /*if (string.IsNullOrEmpty(task.AssigneeId.ToString()))
            {
                throw new NullReferenceException("Task has to be assigned to someone");
            }*/ 
        }
    }
}
