# 📝 TaskifyAPI

A simple yet powerful Task Management Web API built with ASP.NET Core 8.0 using clean architecture principles. It allows users to Create, Read, Update, and Delete tasks (CRUD).

---

## 🚀 Features

- ✅ RESTful API (CRUD operations)
- 🔄 In-Memory Database using EF Core
- 📦 Repository + Service Pattern (clean layered structure)
- 📚 Fully tested via Swagger
- 💡 Ready to migrate to SQL Server & deploy to cloud

---

## 🧱 Tech Stack

- ASP.NET Core 8.0 Web API
- Entity Framework Core (In-Memory DB)
- Swagger / Swashbuckle for testing
- C#, LINQ, Async/Await
- Git + GitHub for version control

---

## 📂 Project Structure

TaskifyAPI/
│
├── Models/
│ └── TaskItem.cs
├── Data/
│ └── ApplicationDbContext.cs
├── Repositories/
│ ├── ITaskRepository.cs
│ └── TaskRepository.cs
├── Services/
│ ├── ITaskService.cs
│ └── TaskService.cs
├── Controllers/
│ └── TaskController.cs
└── Program.cs

---

## 🧪 API Endpoints

| Method | Endpoint       | Description          |
| ------ | -------------- | -------------------- |
| GET    | /api/Task      | Get all tasks        |
| GET    | /api/Task/{id} | Get task by ID       |
| POST   | /api/Task      | Create new task      |
| PUT    | /api/Task/{id} | Update existing task |
| DELETE | /api/Task/{id} | Delete task by ID    |

---

## ▶️ Getting Started

### 1. Clone the Repo

git clone https://github.com/your-username/TaskifyAPI.git
cd TaskifyAPI

2. Run the Project
   dotnet run

Visit: https://localhost:5001/swagger

🧠 Future Plans:-

⛓️ Switch from InMemory to SQL Server

🌐 Deploy to Render / Railway (free)

🧪 Add Unit Tests (XUnit/NUnit)

🌱 Add User Auth (JWT) and Frontend (React)

🤝 Author
Uzair Iqbal
.NET Developer | API Specialist
www.linkedin.com/in/uzair-m-iqbal-760180102
Contact Number :- +923333758131
