using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Task = Model.Task;
using Microsoft.EntityFrameworkCore;


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

        public Model.FilteredList<Task> GetTasks(Model.Filter filter)
        {
            var filteredList = new FilteredList<Task> { FilterUsed = filter };
            var taskList = new List<Task>();

            if (filter.SearchField != null && filter.SearchValue != null)
            {
                switch (filter.SearchField)
                {
                    case "Description": //Where(p => p.Description.Contains(filter.SearchValue))
                        taskList = _ctx.Tasks.Select(t => new Task()
                        {
                            Id = t.Id,
                            AssigneeId = t.AssigneeId,
                            Assignee = t.Assignee,
                            Description = t.Description,
                            DueDate = t.DueDate,
                            IsCompleted = t.IsCompleted

                        }).Where(p => p.Description.Contains(filter.SearchValue)).ToList();
                        break;
                    default:
                        break;
                }
                filteredList.List = taskList;
                filteredList.TotalCount = taskList.Count();
                return filteredList;
            }

            filteredList.List = _ctx.Tasks.Select(t => new Task()
            {
                Id = t.Id,
                AssigneeId = t.AssigneeId,
                Assignee = t.Assignee,
                Description = t.Description,
                DueDate = t.DueDate,
                IsCompleted = t.IsCompleted

            });
            filteredList.TotalCount = _ctx.Tasks.Count();
            return filteredList;
        }

        public Task UpdateTaskStatus(int id, bool isCompleted)
        {

            var task = _ctx.Tasks.FirstOrDefault(t => t.Id == id);
            task.IsCompleted = isCompleted;
            _ctx.Tasks.Attach(task);
            _ctx.Entry(task).Property(x => x.IsCompleted).IsModified = true;
            _ctx.SaveChanges();

            return _ctx.Tasks.FirstOrDefault(t => t.Id == id);
            //_ctx.Tasks.FirstOrDefault(t => t.)
        }

        public Task FindById(int id)
        {
            return _ctx.Tasks.FirstOrDefault(t => t.Id == id);
        }
    }
}
