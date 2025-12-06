using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using HMCTS.logic;
using HMCTS.API.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HMCTS.utests
{
    public class Controllertest
    {
        [Fact]
        public void GetAllTasks_ReturnsOkResult_WithListOfTasks()
        {
            // Arrange
            var mockTaskService = new Mock<ITaskService>();
            mockTaskService.Setup(service => service.GetAllTasks())
                .Returns(new List<TaskModel>
                {
                    new TaskModel("Task 1", "Description 1", "2024-12-31"),
                });
  
            var controller = new TasksController(mockTaskService.Object);
            // Act
            var result = controller.GetAll();
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<TaskModel>>(okResult.Value);
            Assert.Single(returnValue);
            Assert.Equal("Task 1", returnValue[0].Task_Title);
        }
    }
}
