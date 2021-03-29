using DAL;
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
        public List<Task> GetTasksByDescription(string description) => _taskRepository.GetTasksByDescription(description);

        public Task CreateTask(Task task) => _taskRepository.CreateTask(task);

        public Task UpdateTask(Task task) => _taskRepository.UpdateTask(task);

        public Task DeleteTask(int id) => _taskRepository.DeleteTask(id);

    }
}
