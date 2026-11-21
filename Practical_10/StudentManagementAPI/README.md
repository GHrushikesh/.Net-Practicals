# Student Management REST API (ASP.NET Core)

## Practical Details
**Practical Title:** Build Student Management REST API using ASP.NET Core (Middleware, API, Project Structure)  
**Framework:** ASP.NET Core Web API (.NET 8 / .NET 10 compatible)  
**Database:** Microsoft SQL Server (LocalDB / Express)  
**Data Access:** ADO.NET (`Microsoft.Data.SqlClient`)  

---

## 1. Project Structure
The solution follows standard ASP.NET Core layered structure:
```text
StudentManagementAPI/
├── Controllers/
│   └── StudentsController.cs          # REST API endpoints (GET, POST, PUT, DELETE)
├── Middlewares/
│   ├── RequestLoggingMiddleware.cs    # Logs HTTP method, path, status, and duration
│   └── GlobalExceptionMiddleware.cs   # Intercepts unhandled errors and returns JSON
├── Models/
│   └── Student.cs                     # Student entity definition
├── Properties/
│   └── launchSettings.json            # Development port and launch profiles
├── appsettings.json                   # Database connection string and logging configuration
├── Program.cs                         # Application startup, DI & middleware pipeline
├── setup_db.sql                       # Database and table creation script with sample data
├── StudentManagementAPI.csproj        # Project configuration & package dependencies
└── StudentManagementAPI.sln           # Visual Studio solution file
```

---

## 2. Middleware Implementation
Two custom middleware components are implemented in `Middlewares/`:
1. **`RequestLoggingMiddleware`**:
   - Intercepts incoming requests, logs HTTP method, target path, and timestamp.
   - Measures execution time using `Stopwatch`.
   - Logs the resulting HTTP response status code and total elapsed time in milliseconds.
2. **`GlobalExceptionMiddleware`**:
   - Encapsulates the entire request processing pipeline inside a `try-catch` block.
   - Catches unhandled exceptions, logs them, and formats a standardized JSON response with HTTP 500 status.

Both are registered in `Program.cs` before controller mapping.

---

## 3. Database Setup
1. Open SQL Server Management Studio (SSMS) or Visual Studio SQL Server Object Explorer.
2. Connect to `(localdb)\MSSQLLocalDB` (or your local SQL Server instance).
3. Open and execute the included [setup_db.sql](file:///A:/.Net%20Practical/P10%20-%20StudentManagementAPI/P10%20-%20StudentManagementAPI/StudentManagementAPI/setup_db.sql).
4. Verify `appsettings.json` matches your connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentAPI;Integrated Security=True"
   }
   ```

---

## 4. REST API Endpoints

| Method | Endpoint | Description | Sample Request / Response |
| :--- | :--- | :--- | :--- |
| **GET** | `/api/Students` | Get all students | Returns array of `Student` objects |
| **GET** | `/api/Students/{id}` | Get student by ID | Returns student object or `404 Not Found` |
| **POST** | `/api/Students` | Add new student | Body: `{"name":"...","email":"...","course":"..."}` |
| **PUT** | `/api/Students/{id}` | Update student by ID | Body: updated student details |
| **DELETE** | `/api/Students/{id}` | Delete student by ID | Returns success confirmation or `404 Not Found` |

---

## 5. How to Run the Application
1. **Using .NET CLI:**
   ```bash
   dotnet run --project StudentManagementAPI.csproj
   ```
2. **Access Swagger UI:**
   Navigate to [http://localhost:5215/swagger](http://localhost:5215/swagger) in your browser.
