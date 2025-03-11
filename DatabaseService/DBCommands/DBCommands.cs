namespace DatabaseService.DBCommands;

public class DbCommands
{
    public static string CreateDbCommandWithNotExists(string dbName) =>
        $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{dbName}') CREATE DATABASE {dbName};";
    
    public static string UseDbCommand(string dbName) => $"USE {dbName};";
                    
    public static string CreateTablesCommand() => @"
                        CREATE TABLE Users (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            Login NVARCHAR(100) NOT NULL UNIQUE,
                            Password NVARCHAR(100) NOT NULL
                        );
                
                        CREATE TABLE Students (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            UserId INT FOREIGN KEY REFERENCES Users(Id),
                            Name NVARCHAR(100) NOT NULL,
                            Surname NVARCHAR(100) NOT NULL,
                            Course NVARCHAR(50) NOT NULL,
                            CONSTRAINT UQ_Student_User UNIQUE (UserId)
                        );
                
                        CREATE TABLE Marks (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            StudentId INT FOREIGN KEY REFERENCES Students(Id),
                            Average INT NULL
                        );
                
                        CREATE TABLE MarksDetail (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            MarkId INT FOREIGN KEY REFERENCES Marks(Id),
                            Mark INT NOT NULL
                        );
                
                        CREATE TABLE Subjects (
                            Id INT PRIMARY KEY IDENTITY(1,1),
                            Name NVARCHAR(100) NOT NULL,
                            MarkId INT FOREIGN KEY REFERENCES Marks(Id)
                        );
                
                        CREATE TABLE StudentSubjects (
                            StudentId INT FOREIGN KEY REFERENCES Students(Id),
                            SubjectId INT FOREIGN KEY REFERENCES Subjects(Id),
                            PRIMARY KEY (StudentId, SubjectId)
                        );";
                
    public static string DropTablesCommand() => @"
                        DROP TABLE IF EXISTS StudentSubjects;
                        DROP TABLE IF EXISTS Subjects;
                        DROP TABLE IF EXISTS MarksDetail;
                        DROP TABLE IF EXISTS Marks;
                        DROP TABLE IF EXISTS Students;
                        DROP TABLE IF EXISTS Users;";

    public static string InsertUserCommand(string login, string password)
    {
        return $"INSERT INTO Users (Login, Password) VALUES ({login}, {password});";
    }
    
    public static string GetUserCommand => "SELECT * FROM Users WHERE Login = @login;";
}