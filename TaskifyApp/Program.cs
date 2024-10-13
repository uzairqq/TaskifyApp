using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskifyApp.Middleware;
using TaskifyApp.Models;
using TaskifyApp.Repository;
using TaskifyApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TaskifyDbContext>(options =>
    options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));

builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
//builder.Services.AddSingleton<ErrorHandlerMiddleware>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
