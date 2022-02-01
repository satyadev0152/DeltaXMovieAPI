-- Create a new database called 'MovieDB'
-- Connect to the 'MovieDB' database to run this snippet
USE MovieDB
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT name
        FROM sys.databases
        WHERE name = N'MovieDB'
)
CREATE DATABASE MovieDB
GO

-- Create a new table called 'MovieDetails' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.MovieDetils', 'U') IS NOT NULL
DROP TABLE dbo.MovieDetails
GO
-- Create the MovieDetails table in the specified schema
CREATE TABLE dbo.MovieDetails
(
    MovieName [NVARCHAR](50) NOT NULL PRIMARY KEY,
    ActorName [NVARCHAR](50),
    ProducerName [NVARCHAR](50) UNIQUE,
);
GO

-- Create a new table called 'ProducerDetails' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.ProducerDetails', 'U') IS NOT NULL
DROP TABLE dbo.ProducerDetails
GO
-- Create the ProducerDetails able in the specified schema
CREATE TABLE dbo.ProducerDetails
(
    ProducerName [NVARCHAR](50) NOT NULL PRIMARY KEY,
    MovieName [NVARCHAR](50) FOREIGN KEY REFERENCES MovieDetails(MovieName)
);
GO

-- Create a new table called 'ActorDetails' in schema 'dbo'
-- Drop the table if it already exists
IF OBJECT_ID('dbo.ActorDetails', 'U') IS NOT NULL
DROP TABLE dbo.ActorDetails
GO
-- Create the ActorDetails able in the specified schema
CREATE TABLE dbo.ActorDetails
(
    ActorName [NVARCHAR](50) NOT NULL PRIMARY KEY,
    ProducerName [NVARCHAR](50) FOREIGN KEY REFERENCES ProducerDetails(ProducerName)
);
GO





