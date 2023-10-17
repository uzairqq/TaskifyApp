using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Taskify_API.Models;
using Taskify_API.Repository;
using Taskify_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Business Servicess Register
builder.Services.AddScoped<ITaskAppService, TaskAppService>();

//Business Repository Register
builder.Services.AddScoped<ITaskRepository, TaskRepository>();



//Connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<TaskifyDbContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
