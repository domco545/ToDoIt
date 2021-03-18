using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public interface IAssigneeService
    {
        public List<Assignee> GetAllAssignees();
        public Assignee CreateNewAssignee(Assignee asg);
        public Assignee DeleteAssignee(int id);
    }
}
