using System;
using System.Collections.Generic;
using Task = Model.Task;

namespace DAL
{
    public class TaskRepository: ITaskRepository
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
