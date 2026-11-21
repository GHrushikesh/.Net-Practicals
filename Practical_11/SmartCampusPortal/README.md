# Smart Campus Service Portal – Feature Extension (MVC + Database + API)

## Practical Details
**Practical Title:** Develop Smart Campus Service Portal – Feature Extension (Integrate MVC + Database + API)  
**Framework:** ASP.NET MVC 5 & ASP.NET Web API 2 (.NET Framework 4.8)  
**Database:** Microsoft SQL Server (LocalDB / Express)  
**Data Access:** ADO.NET (`System.Data.SqlClient`)  

---

## 1. Project Architecture & Overview
This application integrates **ASP.NET MVC**, **Microsoft SQL Server (via ADO.NET)**, and **ASP.NET Web API** into a single solution:

```text
SmartCampusPortal/
├── App_Start/
│   ├── RouteConfig.cs         # MVC route definitions (default: ServiceRequest/Index)
│   └── WebApiConfig.cs        # Web API routing & attribute routing configuration
├── Controllers/
│   ├── ServiceRequestController.cs  # MVC Controller handling Web Views (Index, Create, UpdateStatus)
│   └── ServiceApiController.cs      # RESTful Web API Controller (GET, POST, PUT)
├── DAL/
│   └── ServiceRequestDAL.cs         # Data Access Layer using ADO.NET (SqlConnection, SqlCommand, SqlDataReader)
├── Models/
│   └── ServiceRequest.cs            # Data Model with validation attributes
├── Views/
│   └── ServiceRequest/
│       ├── Index.cshtml             # View listing all service requests
│       ├── Create.cshtml            # Form view to log a new service request
│       └── UpdateStatus.cshtml      # Form view to modify ticket status
├── Global.asax.cs                   # Application lifecycle and routing registrations
├── setup_db.sql                     # SQL script to create database, table, and sample data
├── Web.config                       # Application settings & database connection string
└── SmartCampusPortal.csproj         # Project configuration file
```

---

## 2. Database Configuration
1. Open **SQL Server Management Studio (SSMS)** or Visual Studio **SQL Server Object Explorer**.
2. Connect to `(localdb)\MSSQLLocalDB` (or your local SQL Server instance).
3. Open and execute `setup_db.sql`.
4. Ensure `Web.config` connection string matches your server instance:
   ```xml
   <connectionStrings>
     <add name="CampusConnection"
          connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SmartCampusDB;Integrated Security=True"
          providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

---

## 3. Web API Endpoints

| HTTP Method | Route | Description | Request Body | Response |
| :--- | :--- | :--- | :--- | :--- |
| **GET** | `/api/ServiceApi` | Retrieve all campus service requests | None | Array of `ServiceRequest` JSON |
| **POST** | `/api/ServiceApi` | Submit a new service request | `ServiceRequest` JSON object | `200 OK` ("Service request created successfully") |
| **PUT** | `/api/ServiceApi/UpdateStatus/{id}` | Update status of request by ID | JSON string (e.g. `"Completed"`) | `200 OK` ("Status updated successfully") |

---

## 4. MVC User Interface

| Route | Controller Action | Description |
| :--- | :--- | :--- |
| `/` or `/ServiceRequest` | `Index` | Tabular display of all submitted service requests with priority, status, and dates |
| `/ServiceRequest/Create` | `Create` | Form to submit student requests with dropdowns for Service Type and Priority |
| `/ServiceRequest/UpdateStatus/{id}` | `UpdateStatus` | Interface to transition request status (Pending, In Progress, Completed) |

---

## 5. How to Run
1. Open `SmartCampusPortal.sln` in **Visual Studio 2022**.
2. Run database setup: Execute `setup_db.sql` on `(localdb)\MSSQLLocalDB`.
3. Press **F5** or **Ctrl + F5** to launch via IIS Express.
4. Browser will open at `http://localhost:59705/` (or configured IIS Express port).
