CREATE TABLE Assignees(
    Id INT IDENTITY(1, 1),
    Name NVARCHAR (100) NOT NULL
);
CREATE TABLE Tasks(
    Id INT IDENTITY(1, 1) NOT NULL,
    Description NVARCHAR (255) NOT NULL,
    AssigneeId INT NOT NULL,
    DueDate DATETIME2,
    isCompleted BIT NOT NULL
);