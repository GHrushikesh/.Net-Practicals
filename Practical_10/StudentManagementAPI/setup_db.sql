-- =======================================================
-- Database Setup Script for Student Management REST API
-- Practical: Build Student Management REST API using ASP.NET Core
-- =======================================================

-- 1. Create Database if it does not exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'StudentAPI')
BEGIN
    CREATE DATABASE StudentAPI;
    PRINT 'Database StudentAPI created successfully.';
END
ELSE
BEGIN
    PRINT 'Database StudentAPI already exists.';
END
GO

USE StudentAPI;
GO

-- 2. Create Students Table if it does not exist
IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.Students;
    PRINT 'Old Students table dropped.';
END
GO

CREATE TABLE dbo.Students (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Course NVARCHAR(100) NOT NULL
);
GO

PRINT 'Students table created successfully.';
GO

-- 3. Insert Initial Sample Records
INSERT INTO dbo.Students (Name, Email, Course) VALUES
('Aarav Sharma', 'aarav.sharma@example.com', 'Computer Science'),
('Diya Patel', 'diya.patel@example.com', 'Information Technology'),
('Rohan Mehta', 'rohan.mehta@example.com', 'Data Science'),
('Ananya Iyer', 'ananya.iyer@example.com', 'Artificial Intelligence');
GO

PRINT 'Sample student records inserted successfully.';
GO

-- 4. Verify Data
SELECT * FROM dbo.Students;
GO
