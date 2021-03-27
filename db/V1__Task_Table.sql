CREATE TABLE Tasks(
    Id INT IDENTITY(1, 1),
    TypeId INT,
    Distance FLOAT
);
CREATE TABLE WorkoutTypes(
    Id INT IDENTITY(1, 1),
    Name NVARCHAR (100) NOT NULL
);