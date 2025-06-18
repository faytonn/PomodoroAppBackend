# Developer Guide

This document gives an overview of the project structure and how the different subprojects interact.

## Solution Overview
This solution's architecture is built with Onion Architecture:
![image](https://github.com/user-attachments/assets/273fdc35-5967-4049-bb5e-2c8d2990b8d0)

The solution is defined by `Pomodoro.Presentation.sln` and contains four main projects:

| Project | Purpose |
| ------- | ------- |
| **Pomodoro.Domain** | Entity and enum definitions shared across the solution. Basically the foundation of the code for models. No external dependencies. |
| **Pomodoro.Application** | Business logic layer. Defines DTOs, service interfaces and AutoMapper mappings. Depends on `Pomodoro.Domain`. |
| **Pomodoro.Persistence** | Data access layer using Entity Framework Core. Contains the `AppDbContext`, migrations and repository classes. Basically in charge of the database information. Depends on `Pomodoro.Domain` and `Pomodoro.Application`. |
| **Pomodoro.Presentation** | ASP.NET Core Web API exposing controllers and configuring the application. Depends on all other projects. |

The project follows a layered architecture where the Presentation layer calls into the Application layer, which in turn uses the Persistence layer to access the database.

## Building the Solution
In Visual Studio, you just go to Build > Build Solution, and the solution will build for you.

## Setup
1. Clone the repository.
2. Update the connection string and other values in `Pomodoro.Presentation/appsettings.json` as needed.
3. Build the solution
4. Apply migrations to create the database (you can do this in View > Other Windows > Package Manager Console and write:
   ```bash
   add-migration initTest
   ```
5. Update the database by writing:
  ```bash
  update-database
 ```
6. Run the API:
7. Navigate to `https://localhost:5001/swagger` (or the port shown in the console) to access the Swagger UI and test the endpoints.

