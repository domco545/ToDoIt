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
            _ctx = ctx;
        }

        public List<Assignee> GetAllAssignees()
        {
            return _ctx.Assignees.ToList();
        }

        public Assignee CreateNewAssignee(Assignee assignee)
        {
            _ctx.Assignees.Add(assignee);
            _ctx.SaveChanges();
            return assignee;

        }

        public Assignee DeleteAssignee(int id)
        {
             var entity =_ctx.Assignees.FirstOrDefault(x => x.Id == id);
            if (entity != null)
            {
                var hasTask = _ctx.Tasks.Any(x => x.AssigneeId == id);
                if (hasTask) throw new Exception("You need remove user's active tasks");
                _ctx.Assignees.Remove(entity);
                _ctx.SaveChanges();
                return entity;

            }
            throw new Exception("Entity Not found");
        }
    }
}
