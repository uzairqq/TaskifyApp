# 📝 TaskifyAPI

A simple yet powerful Task Management Web API built with ASP.NET Core 8.0 using clean architecture principles. It allows users to Create, Read, Update, and Delete tasks (CRUD).

---

## 🚀 Features

- ✅ RESTful API (CRUD operations)
- 💾 SQL Server database with Entity Framework Core
- 🔄 Clean Repository + Service Pattern
- 🧠 Async/Await based async programming
- 📚 Swagger UI for testing

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

## 🧠 Future Plans

- 🌐 Deploy to Render / Railway (free)
- 🧪 Add Unit Tests (XUnit/NUnit)
- 🔐 Add JWT-based Authentication
- 🌱 Build Frontend using React

🤝 Author
Uzair Iqbal
.NET Developer | API Specialist
www.linkedin.com/in/uzair-m-iqbal-760180102
Contact Number :- +923333758131
