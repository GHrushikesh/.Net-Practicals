IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PlacementDB')
BEGIN
    CREATE DATABASE PlacementDB;
END
GO

USE PlacementDB;
GO

IF OBJECT_ID('Placements', 'U') IS NOT NULL DROP TABLE Placements;
IF OBJECT_ID('Students', 'U') IS NOT NULL DROP TABLE Students;
GO

CREATE TABLE Students (
    PlacementId INT NULL,
    StudentId INT PRIMARY KEY,
    StudentName NVARCHAR(100),
    CompanyName NVARCHAR(100) NULL,
    JobRole NVARCHAR(100) NULL,
    PackageLPA DECIMAL(10,2) NULL,
    IsPlaced BIT NOT NULL DEFAULT 0
);
GO

CREATE TABLE Placements (
    PlacementId INT IDENTITY(1,1) PRIMARY KEY,
    StudentId INT,
    CompanyName NVARCHAR(100),
    JobRole NVARCHAR(100),
    PackageLPA DECIMAL(10,2)
);
GO

INSERT INTO Placements (StudentId, CompanyName, JobRole, PackageLPA) VALUES
(101, 'Google', 'Software Engineer', 24.50),
(102, 'Microsoft', 'SDE-1', 18.00),
(103, 'Amazon', 'Cloud Engineer', 20.00),
(104, 'TCS', 'System Associate', 7.50);
GO

INSERT INTO Students (PlacementId, StudentId, StudentName, CompanyName, JobRole, PackageLPA, IsPlaced) VALUES
(1, 101, 'Alice Smith', 'Google', 'Software Engineer', 24.50, 1),
(2, 102, 'Bob Johnson', 'Microsoft', 'SDE-1', 18.00, 1),
(3, 103, 'Charlie Brown', 'Amazon', 'Cloud Engineer', 20.00, 1),
(4, 104, 'David Lee', 'TCS', 'System Associate', 7.50, 1),
(NULL, 105, 'Eva Green', NULL, NULL, 0.00, 0),
(NULL, 106, 'Frank White', NULL, NULL, 0.00, 0);
GO

