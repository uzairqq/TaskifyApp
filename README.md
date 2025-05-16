# 📝 TaskifyAPI

A simple yet powerful Task Management Web API built with ASP.NET Core 8.0 using clean architecture principles. It allows users to Create, Read, Update, and Delete tasks (CRUD).

---

## 🚀 Features

- ✅ RESTful API with full CRUD
- 🔄 DTO-based architecture (Create, Update, Read)
- 🧠 Mapping handled in Service layer for clean controllers
- 💾 SQL Server database using Entity Framework Core 8
- 🧪 Swagger UI for testing endpoints
- ✅ Model validation using Data Annotations + ModelState

---

## 🧱 Tech Stack

- **.NET 8.0** — Framework for building Web APIs
- **C#** — Primary programming language
- **ASP.NET Core Web API** — Backend RESTful services
- **Entity Framework Core 8** — ORM for SQL Server
- **SQL Server** — Real production-grade database
- **DTOs** — Used for clean data transfer and validation
- **Swagger (Swashbuckle)** — API documentation & testing
- **Dependency Injection** — For service and repository registration
- **LINQ + Async/Await** — Modern data querying and performance
- **Model Validation (DataAnnotations)** — Input validation and error handling

---

## 📂 Project Structure

TaskifyAPI/
│
├── Models/ → Entity classes (e.g., TaskItem)
├── DTOs/ → Clean data transfer classes (e.g., TaskUpsertDto, TaskReadDto)
├── Data/ → EF Core DbContext (ApplicationDbContext)
├── Repositories/ → ITaskRepository + TaskRepository (Data access layer)
├── Services/ → ITaskService + TaskService (Business logic + DTO mapping)
├── Controllers/ → TaskController (lean controller, no mapping)
├── Migrations/ → EF Core migration history (SQL schema)
└── Program.cs → Dependency Injection + EF + Routing setup

---

## 📐 Design Decisions

- Followed Clean Architecture principles
- Used DTOs for separation of concerns and security
- Moved all entity-DTO mapping to Service layer (Controller is lean)
- Centralized validation at DTO level using Data Annotations
- Async Task-based methods for scalability

## ▶️ Getting Started

### 1. Clone the Repo

git clone https://github.com/uzairqq/Todo-App
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
