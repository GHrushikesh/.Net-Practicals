Add-Type -AssemblyName System.Data
$cs = 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True'
$con = New-Object System.Data.SqlClient.SqlConnection($cs)
$con.Open()

$cmd = $con.CreateCommand()
$cmd.CommandText = "IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'InventoryDB') CREATE DATABASE InventoryDB;"
[void]$cmd.ExecuteNonQuery()

$con.ChangeDatabase("InventoryDB")

$cmd.CommandText = @"
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Products' AND xtype='U')
BEGIN
    CREATE TABLE Products (
        ProductId INT PRIMARY KEY,
        ProductName NVARCHAR(100),
        Quantity INT,
        Price DECIMAL(18, 2)
    );
END
"@
[void]$cmd.ExecuteNonQuery()
$con.Close()
Write-Output "Database InventoryDB and Table Products created successfully!"
