# Taskify - Todo API (ASP.NET Core 8)

## ✅ Step 1: Project Setup
- Created new Web API project using .NET 8
- Deleted default controller and model
- Swagger is working

### 🔗 Commands used:
dotnet new webapi -n TaskifyAPI
dotnet run

✅ Commit Message: `Initial commit - Created .NET 8 Web API project`


## ✅ Step 2: EF Core + Model Setup

- Added TaskItem model in `Models/`
- Installed EF Core + SQLite
- Created AppDbContext and registered it
- Applied EF migration and created SQLite DB

### 🔗 Commands used:
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet ef migrations add InitialCreate
dotnet ef database update

✅ Commit: `Step 2: Added TaskItem model, EF Core, AppDbContext, migration`


## ✅ Step 3: TasksController with CRUD

- Created `TasksController.cs` in `Controllers/`
- Added routes:
  - `GET /api/tasks`
  - `GET /api/tasks/{id}`
  - `POST /api/tasks`
  - `PUT /api/tasks/{id}`
  - `DELETE /api/tasks/{id}`
- Tested using Swagger

✅ Commit: `Step 3: Added TasksController with full CRUD operations`