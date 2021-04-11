using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BLL.Validators;
using FluentAssertions;
using Model;
using Xunit;

namespace UnitTest
{
   public class TaskValidatorTest
    {
        [Fact]
        public void ValidateInput_WithTaskDescriptionEmpty_ShouldThrowException()
        {
            var taskValidator = new TaskValidator();
            Action action = () => taskValidator.ValidateTask(new Task(){Id = 1, AssigneeId = 1, Assignee = new Assignee(){Id = 1, Name = "Dave"},Description = "",DueDate = DateTime.Now});
            action.Should().Throw<InvalidDataException>().WithMessage("Task must have a description");
        }
        [Fact]
        public void ValidateInput_WithTaskDescriptionNull_ShouldThrowException()
        {
            var taskValidator = new TaskValidator();
            Action action = () => taskValidator.ValidateTask(new Task() { Id = 1, AssigneeId = 1, Assignee = new Assignee() { Id = 1, Name = "Dave" }, DueDate = DateTime.Now });
            action.Should().Throw<InvalidDataException>().WithMessage("Task must have a description");
        }
        [Fact]
        public void ValidateInput_WithTaskDescLength_ShouldThrowException()
        {
            var taskValidator = new TaskValidator();
            Action action = () => taskValidator.ValidateTask(new Task() { Id = 1, AssigneeId = 1, Assignee = new Assignee() { Id = 1, Name = "Dave" }, Description = "AYY", DueDate = DateTime.Now });
            action.Should().Throw<InvalidDataException>().WithMessage("Task description has to be at least 5 characters long");
        }

        [Fact]
        public void ValidateInput_WithTaskAssigneeNull_ShouldThrowException()
        {
            var taskValidator = new TaskValidator();
            Action action = () => taskValidator.ValidateTask(new Task() { Id = 1, AssigneeId = 1,  Description = "Do this task", DueDate = DateTime.Now });
            action.Should().Throw<InvalidDataException>().WithMessage("Task has to be assigned to someone");
        }
    }
}
