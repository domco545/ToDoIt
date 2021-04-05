using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public interface ITaskService
    {
        FilteredList<Task> GetTasks(Filter filter);
        public Task CreateTask(Task task);
        public Task UpdateTask(Task task);
        public Task UpdateTaskStatus(int id, bool isCompleted);
        public Task DeleteTask(int id);


    }
}
