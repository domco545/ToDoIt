using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Assignee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}