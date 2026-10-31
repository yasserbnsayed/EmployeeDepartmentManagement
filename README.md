# Employee & Department Management System

A web-based Employee & Department Management System developed using **C#, ASP.NET Core MVC, Entity Framework Core, SQL Server, and AutoMapper**.

The application provides CRUD operations for managing employees and departments, following a **3-Layer Architecture** to achieve separation of concerns, maintainability, and organized code.

## 🚀 Technologies & Tools

- **Programming Language:** C#
- **Framework:** ASP.NET Core MVC
- **ORM:** Entity Framework Core
- **Database:** Microsoft SQL Server
- **Object Mapping:** AutoMapper
- **Architecture:** 3-Layer Architecture (PL, BLL, DAL)
- **Design Patterns:** Generic Repository Pattern, Unit of Work Pattern
- **Database Approach:** Code First, Fluent API, EF Core Migrations

## ✨ Features

### Employee Management
- Create, view, update, and delete employee records.
- Upload and delete employee profile images.
- Manage employee information and department assignments.

### Department Management
- Create, view, update, and delete department records.
- Manage department information.

### Database Management
- SQL Server database integration.
- Entity Framework Core Code First approach.
- Fluent API configurations.
- Database schema management using EF Core Migrations.

### Code Architecture & Design Patterns
- 3-Layer Architecture (Presentation, Business Logic, and Data Access).
- Generic Repository Pattern for reusable data access operations.
- Unit of Work Pattern for managing data operations.
- AutoMapper for mapping between Entities and ViewModels.
- Separation of Concerns for maintainable and organized code.

## 🏗️ Project Architecture

The application follows a **3-Layer Architecture**:

| Layer | Project | Responsibility |
|---|---|---|
| Presentation Layer | Demo.PL | Handles the user interface and user interactions. |
| Business Logic Layer | Demo.BLL | Contains business logic and application operations. |
| Data Access Layer | Demo.DAL | Handles database access and data persistence. |

### Project Structure

```text
EmployeeDepartmentManagement/
│
├── Demo.PL/       # Presentation Layer
│
├── Demo.BLL/      # Business Logic Layer
│
├── Demo.DAL/      # Data Access Layer
│
├── Demo.PL Solution.sln
│
└── README.md
```

## ⚙️ Getting Started

### Prerequisites

- Visual Studio 2022
- .NET SDK compatible with the project
- Microsoft SQL Server
- SQL Server Management Studio (SSMS) (optional)

### Installation

**1. Clone the repository**

```bash
git clone https://github.com/yasserbnsayed/EmployeeDepartmentManagement.git
```

**2. Open the solution**

Open the solution file in Visual Studio.

**3. Configure the database connection**

Update the connection string in `appsettings.json` according to your SQL Server configuration.

**4. Apply database migrations**

Use the Package Manager Console in Visual Studio and run:

```powershell
Update-Database
```

Make sure the correct migrations project and startup project are selected before running the command.

**5. Run the application**

Set `Demo.PL` as the startup project, build the solution, and run the application.

## 🎯 Learning Objectives

This project demonstrates practical experience in:

- Building ASP.NET Core MVC applications.
- Implementing 3-Layer Architecture.
- Applying Generic Repository and Unit of Work Design Patterns.
- Working with Entity Framework Core and SQL Server.
- Configuring entities using Fluent API.
- Managing database schemas with Code First Migrations.
- Using AutoMapper and ViewModels.
- Implementing CRUD operations and file management.

## 👨‍💻 Author

**Yasser Sayed**

- GitHub: [yasserbnsayed](https://github.com/yasserbnsayed)
- Repository: [EmployeeDepartmentManagement](https://github.com/yasserbnsayed/EmployeeDepartmentManagement)
