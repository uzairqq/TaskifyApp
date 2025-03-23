using TaskifyAPI.Models;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TaskifyAPI.Services.Implementation;
using TaskifyAPI.Services.Interface;
using TaskifyAPI.Repositories.Interface;
using TaskifyAPI.Repositories.Implementation;
using TaskifyAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TaskifyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TaskifyDbContext"));
});


// Add built-in logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddScoped<ITodoServices, TodoService>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskifyAPI v1"));
}
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
