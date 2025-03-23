using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskifyAPI.Controllers;
using TaskifyAPI.Dtos;
using TaskifyAPI.Services.Implementation;
using TaskifyAPI.Services.Interface;

namespace TaskifyAPI.Tests.Controllers
{
    public class TodoControllerTests
    {
        private readonly TodoController _controller;
        private readonly Mock<ITodoServices> _todoServiceMock;

        public TodoControllerTests()
        {
            _todoServiceMock = new Mock<ITodoServices>();
            _controller = new TodoController(_todoServiceMock.Object);
        }

        [Fact]
        public async Task GetAllTodos_ShouldReturnOkResult_WithTodoList()
        {
            // Arrange
            var todos = new List<TodoDto>
            {
                new TodoDto { Id = 1, Title = "Task 1" },
                new TodoDto { Id = 2, Title = "Task 2" }
            };
            _todoServiceMock.Setup(service => service.GetAllTodos()).ReturnsAsync(todos);

            // Act
            var result = await _controller.GetAllTodos();

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult!.Value.Should().BeEquivalentTo(todos);
        }


        [Fact]
        public async Task GetTodoById_ShouldReturnOk_WhenTodoExists()
        {
            // Arrange
            var todo = new TodoDto { Id = 1, Title = "Task 1" };
            _todoServiceMock.Setup(service => service.GetTodoById(1)).ReturnsAsync(todo);

            // Act
            var result = await _controller.GetTodoById(1);

            // Assert
            result.Should().BeOfType<OkObjectResult>();
            var okResult = result as OkObjectResult;
            okResult!.Value.Should().Be(todo);
        }

        [Fact]
        public async Task GetTodoById_ShouldReturnNotFound_WhenTodoDoesNotExist()
        {
            // Arrange
            _todoServiceMock.Setup(service => service.GetTodoById(99)).ReturnsAsync((TodoDto)null);

            // Act
            var result = await _controller.GetTodoById(99);

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }


        [Fact]
        public async Task AddTodo_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var newTodo = new TodoDto { Title = "New Task" };
            _todoServiceMock.Setup(service => service.AddTodo(newTodo)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.AddTodo(newTodo);

            // Assert
            result.Should().BeOfType<CreatedAtActionResult>();
        }

        [Fact]
        public async Task UpdateTodo_ShouldReturnNoContent_WhenUpdatedSuccessfully()
        {
            // Arrange
            var updatedTodo = new TodoDto { Title = "Updated Task" };
            _todoServiceMock.Setup(service => service.UpdateTodo(1, updatedTodo)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdateTodo(1, updatedTodo);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async Task DeleteTodo_ShouldReturnNoContent_WhenDeletedSuccessfully()
        {
            // Arrange
            _todoServiceMock.Setup(service => service.DeleteTodo(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteTodo(1);

            // Assert
            result.Should().BeOfType<NoContentResult>();
        }
    }
}
