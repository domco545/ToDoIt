using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BLL.Validators
{
   public class AssigneeValidator
   {
       private string[] specialchars =
       {
           "+", "-", "&", "||", "!", "(", ")", "{", "}", "[", "]", "^",
           "~", "*", "?", ":", "/", "@", "$", "#", "<", ">","="
       };
        public void ValidateAssignee(Assignee assignee)
        {
            if (string.IsNullOrEmpty(assignee.Name))
            {
                throw new InvalidDataException("Assignee must have a name");
            }

            if (assignee.Name.Length < 3)
            {
                throw new InvalidDataException("Assignee name has to be at least 3 characters long");
            }

            for (int i = 0; i < specialchars.Length; i++)
            {
                if (assignee.Name.Contains(specialchars[i]))
                {
                    throw new InvalidDataException("Assignee name cannot contain any special characters");
                }
            }
        }
    }
}
