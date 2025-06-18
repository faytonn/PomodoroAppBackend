# Pomodoro App Backend

This repository contains the backend for a Pomodoro time management application. The API is built with ASP.NET Core and Entity Framework Core and exposes endpoints for user authentication, tasks, sessions and statistics management.

## Features
- User registration and login with JWT authentication
- CRUD operations for Pomodoro tasks, focus sessions and Pomodoro sessions
- "Site blocking" and user statistics
- Email notifications (not implemented yet)
- Swagger UI for exploring the API

## Prerequisites
- All the packages installed:
         AutoMapper 14.0.0,
         Microsoft.AspNetCore.Http.Features 2.3.0,
         Microsoft.AspNetCore.Http.Abstractions 2.3.0,
         Microsoft.AspNetCore.Identity.EntityFrameworkCore 8.0.15,
         Microsoft.EntityFrameworkCore 8.0.15
         Microsoft.EntityFrameworkCore.SqlServer 8.0.15,
         Microsoft.EntityFrameworkCore.Tools 8.0.15,
         Microsoft.AspNetCore.Authentication.JwtBearer 8.0.15,
         Microsoft.AspNetCore.Components.Web 8.0.15,
         Microsoft.AspNetCore.Mvc.NewtonsoftJson 8.0.15,
         Microsoft.EntityFrameworkCore.Design 8.0.15,
         Swashbuckle.AspNetCore 6.6.2
         
- SQL Server for the database
- If you want to see the frontend UI of it too, pull the frontend repository too: https://github.com/faytonn/PomodoroApp

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

## Final
At the end, you will need to see this to see that everything is successful:
![image](https://github.com/user-attachments/assets/c351d400-3679-4036-81fd-de5eb3ef92d1)
