using System;
using System.Collections.Generic;
using System.Linq;
using Task = Model.Task;

namespace DAL
{

    public class TaskRepository : ITaskRepository
    {
        private readonly TodoContext _ctx;

        public TaskRepository(TodoContext ctx)
        {
            _ctx = ctx;
        }
        public List<Task> GetTasksByDescription(string description)
        {
            return _ctx.Tasks.Where(x => x.Description.Contains(description)).ToList();
        }

        public Task CreateTask(Task task)
        {
            task.IsCompleted = false;
            _ctx.Tasks.Add(task);
            _ctx.SaveChanges();
            if (task.Id > 0)
                return task;
            throw new Exception("Task can be insert");
        }

        public Task UpdateTask(Task task)
        {
            _ctx.Entry(task).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _ctx.SaveChanges();
            return task;
        }

        public Task DeleteTask(int id)
        {
            var entity = _ctx.Tasks.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                _ctx.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                _ctx.SaveChanges();
                return entity;
            }
            throw new Exception("Task Not Found!");

        }
    }
}
