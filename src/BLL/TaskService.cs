﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Model.Task;

namespace BLL
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task CreateTask(Task task) => _taskRepository.CreateTask(task);

        public Task UpdateTask(Task task) => _taskRepository.UpdateTask(task);

        public Task DeleteTask(int id) => _taskRepository.DeleteTask(id);

        public Model.FilteredList<Task> GetTasks(Model.Filter filter)
        {
            if (!string.IsNullOrEmpty(filter.SearchField) && string.IsNullOrEmpty(filter.SearchValue))
            {
                throw new ArgumentException("searchValue cannot be null if searchField is defined.", nameof(filter));
            }

            if (string.IsNullOrEmpty(filter.SearchField) && !string.IsNullOrEmpty(filter.SearchValue))
            {
                throw new ArgumentException("searchField cannot be null if searchValue is defined.", nameof(filter));
            }

            return _taskRepository.GetTasks(filter);
        }
    }
}
