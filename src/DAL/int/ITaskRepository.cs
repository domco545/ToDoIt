using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public interface ITaskRepository
    {
        public List<Task> GetTasksByQuerry(string querry);
        public Task CreateTask(Task task);
        public Task UpdateTask(Task task);
        public Task DeleteTask(int id);
    }
}
