USE master;
GO
DROP DATABASE IF EXISTS OnlineExam;
GO

-- Create the database
CREATE DATABASE OnlineExam;
GO

-- Use the database
USE OnlineExam;
GO

-- Create the Users table
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50),
    Email VARCHAR(100),
    Password VARCHAR(100)
);

-- Create the Exams table
CREATE TABLE Exams (
    ExamID VARCHAR(50) PRIMARY KEY,
    Title VARCHAR(100),
    Description VARCHAR(500),
    StartTime DATETIME,
    EndTime DATETIME
);

-- Create the Questions table
CREATE TABLE Questions (
    QuestionID VARCHAR(50) PRIMARY KEY,
    ExamID VARCHAR(50),
    QuestionText VARCHAR(500),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);

-- Create the Options table
CREATE TABLE Options (
    OptionID INT IDENTITY(1,1) PRIMARY KEY,
    QuestionID VARCHAR(50),
    OptionText VARCHAR(200),
    IsCorrectOption BIT,
    FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)
);

-- Create the UserAnswers table
CREATE TABLE UserAnswers (
    UserAnswerID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    ExamID VARCHAR(50),
    QuestionID VARCHAR(50),
    SelectedOptionID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID),
    FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID),
    FOREIGN KEY (SelectedOptionID) REFERENCES Options(OptionID)
);

-- Create the Results table
CREATE TABLE Results (
    ResultID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT,
    ExamID VARCHAR(50),
    Marks INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);
