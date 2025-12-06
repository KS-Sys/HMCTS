using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using HMCTS.logic;
using HMCTS.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HMCTS.utests
{
    public class Tasktest
    {
        [Fact]
        public void Create_tasktest_R200()
        {
            var mockTaskService = new Mock<ITaskService>();
            var controller = new TasksController(mockTaskService.Object);

            var task = new TaskModel("Test Task", "This is a test task", "2024-12-31 21:00:00");

            var result = controller.Create(task);

            var OK = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Task Created Successfully", OK.Value);

            mockTaskService.Verify(s => s.Create_Task(task), Times.Once);
        }
    }
}
