using System;
using Model;

namespace API.dtos
{



    public class TaskDto
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public AssigneeDto AssigneeDto { get; set; }
        public string dueDate { get; set; }
        public bool isCompleted { get; set; }
    }
}
