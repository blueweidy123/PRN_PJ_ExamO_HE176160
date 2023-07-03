-- Create the database
CREATE DATABASE OnlineExam;

-- Use the database
USE OnlineExam;

-- Create the Users table
CREATE TABLE Users (
    UserID INT PRIMARY KEY,
    Name VARCHAR(50),
    Email VARCHAR(100),
    Password VARCHAR(100)
);

-- Create the Exams table
CREATE TABLE Exams (
    ExamID INT PRIMARY KEY,
    Title VARCHAR(100),
    Description VARCHAR(500),
    StartTime DATETIME,
    EndTime DATETIME
);

-- Create the Questions table
CREATE TABLE Questions (
    QuestionID INT PRIMARY KEY,
    ExamID INT,
    QuestionText VARCHAR(500),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);

-- Create the Options table
CREATE TABLE Options (
    OptionID INT PRIMARY KEY,
    QuestionID INT,
    OptionText VARCHAR(200),
    IsCorrectOption BIT,
    FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID)
);

-- Create the UserAnswers table
CREATE TABLE UserAnswers (
    UserAnswerID INT PRIMARY KEY,
    UserID INT,
    ExamID INT,
    QuestionID INT,
    SelectedOptionID INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID),
    FOREIGN KEY (QuestionID) REFERENCES Questions(QuestionID),
    FOREIGN KEY (SelectedOptionID) REFERENCES Options(OptionID)
);

-- Create the Results table
CREATE TABLE Results (
    ResultID INT PRIMARY KEY,
    UserID INT,
    ExamID INT,
    Marks INT,
    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)
);
