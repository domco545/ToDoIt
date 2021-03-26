using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Model.Task;

namespace BLL
{
    public class TaskService: ITaskService
    {
        public List<Task> GetTasksByQuerry(string querry)
        {
            throw new NotImplementedException();
        }

        public Task CreateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
