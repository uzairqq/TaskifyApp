using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskifyAPI.Dtos;
using TaskifyAPI.Models;
using TaskifyAPI.Repositories.Interface;
using TaskifyAPI.Services.Implementation;

namespace TaskifyAPI.Tests.Services
{
    public class TaskServiceTests
    {
        private readonly TodoService _todoService;
        private readonly Mock<ITodoRepository> _todoRepositoryMock;

        public TaskServiceTests()
        {
            _todoRepositoryMock = new Mock<ITodoRepository>();
            _todoService = new TodoService(_todoRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllTasks_ShouldReturnTasks()
        {
            // Arrange
            var todoList = new List<Todo> { new Todo { Id = 1, Title = "Test Task" } };

            _todoRepositoryMock
                .Setup(repo => repo.GetAllTodos())
                .ReturnsAsync(todoList); // Ensure this returns Task<List<TodoDto>>

            // Act
            var result = await _todoService.GetAllTodos();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Title.Should().Be("Test Task");
        }

        [Fact]
        public async Task GetTodoById_ShouldReturnTodo_WhenTodoExists()
        {
            // Arrange
            var todo = new Todo { Id = 12, Title = "Learn Chapter 12" };
            _todoRepositoryMock.Setup(repo => repo.GetTodoById(12)).ReturnsAsync(todo);

            // Act
            var result = await _todoService.GetTodoById(12);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(12);
            result.Title.Should().Be("Learn Chapter 12");
        }

        [Fact]
        public async Task AddTodo_ShouldCallRepositoryOnce()
        {
            // Arrange
            var newTodoDto = new TodoDto
            {
                Title = "New Task",
                Description = "Task Description",
                DueDate = DateTime.UtcNow,
                IsCompleted = false,
                Status = 1
            };

            _todoRepositoryMock.Setup(repo => repo.AddTodo(It.IsAny<Todo>()))
                .Returns(Task.CompletedTask);

            // Act
            await _todoService.AddTodo(newTodoDto);

            // Assert
            _todoRepositoryMock.Verify(
                repo => repo.AddTodo(It.Is<Todo>(t =>
                    t.Title == newTodoDto.Title &&
                    t.Description == newTodoDto.Description &&
                    t.DueDate == newTodoDto.DueDate &&
                    t.IsCompleted == newTodoDto.IsCompleted &&
                    t.Status == newTodoDto.Status &&
                    t.IsUpdated == false &&
                    t.IsDeleted == false &&
                    t.UserId == 1
                )),
                Times.Once
            );
        }

        [Fact]
        public async Task UpdateTodo_ShouldCallRepositoryOnce_WhenTodoExists()
        {
            // Arrange
            int todoId = 1;
            var existingTodo = new Todo
            {
                Id = todoId,
                Title = "Old Title",
                Description = "Old Description",
                DueDate = DateTime.UtcNow,
                IsCompleted = false,
                Status = 1,
                IsUpdated = false
            };

            var updatedTodoDto = new TodoDto
            {
                Title = "Updated Title",
                Description = "Updated Description",
                DueDate = DateTime.UtcNow.AddDays(2),
                IsCompleted = true,
                Status = 2
            };

            _todoRepositoryMock.Setup(repo => repo.GetTodoById(todoId))
                .ReturnsAsync(existingTodo);

            _todoRepositoryMock.Setup(repo => repo.UpdateTodo(It.IsAny<Todo>()))
                .Returns(Task.CompletedTask);

            // Act
            await _todoService.UpdateTodo(todoId, updatedTodoDto);

            // Assert
            _todoRepositoryMock.Verify(
     repo => repo.UpdateTodo(It.Is<Todo>(
         t => t.Id == todoId &&
              t.Title == updatedTodoDto.Title &&
              t.Description == updatedTodoDto.Description
     )),
     Times.Once
 );

            _todoRepositoryMock.Verify(
                repo => repo.UpdateTodo(It.Is<Todo>(t =>
                    t.Id == todoId &&
                    t.Title == updatedTodoDto.Title &&
                    t.Description == updatedTodoDto.Description &&
                    t.DueDate == updatedTodoDto.DueDate &&
                    t.IsCompleted == updatedTodoDto.IsCompleted &&
                    t.Status == updatedTodoDto.Status &&
                    t.IsUpdated == true
                )),
                Times.Once
            );
        }

        [Fact]
        public async Task DeleteTodo_ShouldCallRepositoryOnce()
        {
            // Arrange
            int todoId = 1;

            _todoRepositoryMock.Setup(repo => repo.DeleteTodo(todoId))
                .Returns(Task.CompletedTask);

            // Act
            await _todoService.DeleteTodo(todoId);

            // Assert
            _todoRepositoryMock.Verify(repo => repo.DeleteTodo(todoId), Times.Once);
        }
    }
}
