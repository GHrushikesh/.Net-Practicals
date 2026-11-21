-- =======================================================
-- Database Setup Script for Smart Campus Service Portal
-- Practical: Develop Smart Campus Service Portal – Feature Extension
-- (Integrate MVC + Database + API)
-- =======================================================

-- 1. Create Database if it does not exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'SmartCampusDB')
BEGIN
    CREATE DATABASE SmartCampusDB;
    PRINT 'Database SmartCampusDB created successfully.';
END
ELSE
BEGIN
    PRINT 'Database SmartCampusDB already exists.';
END
GO

USE SmartCampusDB;
GO

-- 2. Create ServiceRequests Table
IF OBJECT_ID('dbo.ServiceRequests', 'U') IS NOT NULL
BEGIN
    PRINT 'Table ServiceRequests already exists.';
END
ELSE
BEGIN
    CREATE TABLE dbo.ServiceRequests (
        RequestId INT IDENTITY(1,1) PRIMARY KEY,
        StudentName NVARCHAR(100) NOT NULL,
        Department NVARCHAR(100) NOT NULL,
        ServiceType NVARCHAR(100) NOT NULL,
        Description NVARCHAR(MAX) NOT NULL,
        Priority NVARCHAR(50) DEFAULT 'Medium',
        Status NVARCHAR(50) DEFAULT 'Pending',
        RequestDate DATETIME DEFAULT GETDATE()
    );
    PRINT 'Table ServiceRequests created successfully.';
END
GO

-- 3. Insert Sample Service Requests
IF NOT EXISTS (SELECT 1 FROM dbo.ServiceRequests)
BEGIN
    INSERT INTO dbo.ServiceRequests 
    (StudentName, Department, ServiceType, Description, Priority, Status, RequestDate)
    VALUES 
    ('John Doe', 'Computer Science', 'Wi-Fi Access', 'Cannot connect to campus Wi-Fi in Lab 3', 'High', 'Pending', GETDATE()),
    ('Jane Smith', 'Electrical Engineering', 'Lab Equipment', 'Oscilloscope calibration needed in Room 204', 'Medium', 'In Progress', GETDATE()),
    ('Alex Turner', 'Mechanical Engineering', 'Maintenance', 'Air conditioning repair in Workshop 1', 'High', 'Completed', GETDATE());

    PRINT 'Sample service request records inserted successfully.';
END
ELSE
BEGIN
    PRINT 'Table already contains records; skipping seed data.';
END
GO
