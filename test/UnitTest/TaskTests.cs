using System;
using BLL;
using DAL;
using FluentAssertions;
using Moq;
using Xunit;

namespace UnitTest
{
    public class TaskTests
    {

        private readonly Mock<ITaskRepository> _taskMockRepo;
        private readonly ITaskService _taskService;

        public TaskTests()
        {
            _taskMockRepo = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskMockRepo.Object);
        }

        [Fact]
        public void TaskService_ShouldBeOfTypeITaskService()
        {
            new TaskService(_taskMockRepo.Object).Should().BeAssignableTo<ITaskService>();
        }

        [Fact]
        public void GetAll_ShouldCallTaskRepo_Once()
        {
            TaskService taskService = new TaskService(_taskMockRepo.Object);
            Model.Filter filter = new Model.Filter();
            taskService.GetTasks(filter);
            _taskMockRepo.Verify(repo => repo.GetTasks(filter), Times.Once);
        }



        [Fact]
        public void GetAll_FilterDefinedPartiallyWithSearchField_ShouldThrowException()
        {
            Model.Filter filter = new Model.Filter();
            filter.SearchField = "Description";
            Action action = () => _taskService.GetTasks(filter);
            action.Should().Throw<ArgumentException>()
               .WithMessage("searchValue cannot be null if SearchField is defined. (Parameter 'filter')");
        }


        [Fact]
        public void GetAll_FilterDefinedPartiallyWithSearchValue_ShouldThrowException()
        {
            Model.Filter filter = new Model.Filter();
            filter.SearchValue = "Do Laundr";
            Action action = () => _taskService.GetTasks(filter);
            action.Should().Throw<ArgumentException>()
               .WithMessage("searchField cannot be null if SearchValue is defined. (Parameter 'filter')");
        }


        [Fact]
        public void UpdateTaskStatus_ShouldCallTaskRepo_Once()
        {
            _taskService.UpdateTaskStatus(1, true);
            _taskMockRepo.Verify(repo => repo.UpdateTaskStatus(1, true), Times.Once);
        }

    }

}