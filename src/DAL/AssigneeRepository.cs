using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class AssigneeRepository : IAssigneeRepository
    {

        private readonly TodoContext _ctx;

        public AssigneeRepository(TodoContext ctx)
        {
            ctx = _ctx;
        }

        public List<Assignee> GetAllAssignees()
        {
            return _ctx.Assignees.ToList();
        }

        public Assignee CreateNewAssignee(Assignee asg)
        {
            throw new NotImplementedException();
        }

        public Assignee DeleteAssignee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
