using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Validators;
using FluentAssertions;
using Model;
using Xunit;
using Task = Model.Task;

namespace UnitTest
{
  public  class AssigneeValidatorTest
    {

        [Fact]
        public void ValidateInput_WithAssigneeNameEmpty_ShouldThrowException()
        {
            var assigneeValidator = new AssigneeValidator();
            Action action = () => assigneeValidator.ValidateAssignee(new Assignee(){Id = 1,Name = ""});
            action.Should().Throw<InvalidDataException>().WithMessage("Assignee must have a name");
        }
        [Fact]
        public void ValidateInput_WithAssigneeNameNull_ShouldThrowException()
        {
            var assigneeValidator = new AssigneeValidator();
            Action action = () => assigneeValidator.ValidateAssignee(new Assignee() { Id = 1});
            action.Should().Throw<InvalidDataException>().WithMessage("Assignee must have a name");
        }
        [Fact]
        public void ValidateInput_WithAssigneeNameLength_ShouldThrowException()
        {
            var assigneeValidator = new AssigneeValidator();
            Action action = () => assigneeValidator.ValidateAssignee(new Assignee() { Id = 1, Name = "AB" });
            action.Should().Throw<InvalidDataException>().WithMessage("Assignee name has to be at least 3 characters long");
        }

        [Theory]
        [InlineData("#")]
        [InlineData("$")]
        [InlineData("!")]
        [InlineData("@")]
        [InlineData("&")]
        [InlineData("?")]
        public void ValidateInput_WithAssigneeNameSpecialChars_ShouldThrowException(string character)
        {
            var assigneeValidator = new AssigneeValidator();
            Action action = () => assigneeValidator.ValidateAssignee(new Assignee() { Id = 1, Name = "ABD"+character });
            action.Should().Throw<InvalidDataException>().WithMessage("Assignee name cannot contain any special characters");
        }
    }
}
