using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Validators;
using DAL;
using Model;


namespace BLL
{
    public class AssigneeService : IAssigneeService
    {
        private readonly IAssigneeRepository _assigneeRepo;

        public AssigneeService(IAssigneeRepository assigneeRepo)
        {
            _assigneeRepo = assigneeRepo;
        }

        public List<Assignee> GetAllAssignees()
        {
            return _assigneeRepo.GetAllAssignees();
        }

        public Assignee CreateNewAssignee(Assignee assignee)
        {
            new AssigneeValidator().ValidateAssignee(assignee);
            return _assigneeRepo.CreateNewAssignee(assignee);
        }

        public Assignee DeleteAssignee(int id)
        {
            return _assigneeRepo.DeleteAssignee(id);
        }
    }
}