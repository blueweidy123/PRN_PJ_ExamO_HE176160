
USE OnlineEnExam;

	/*
	DELETE FROM Users;
	*/
INSERT INTO Users (Name, Email, Password)
VALUES
    (N'Nguyen Van A', 'nva@example.com', '123'),
    (N'Nguyen Thi B', 'ntb@example.com', '123'),
    (N'Nguyen Van C', 'nvc@example.com', '123'),
    (N'Nguyen Thi D', 'ntd@example.com', '123'),
    (N'Nguyen Van E', 'nve@example.com', '123'),
    (N'Nguyen Thi F', 'ntf@example.com', '123'),
    (N'Nguyen Van G', 'nvg@example.com', '123'),
    (N'Nguyen Thi H', 'nth@example.com', '123'),
    (N'Nguyen Van I', 'nvi@example.com', '123'),
    (N'Nguyen Thi K', 'ntk@example.com', '123'),
    (N'Nguyen Van L', 'nvl@example.com', '123'),
    (N'Nguyen Thi M', 'ntm@example.com', '123'),
    (N'Nguyen Van N', 'nvn@example.com', '123'),
    (N'Nguyen Thi P', 'ntp@example.com', '123'),
    (N'Nguyen Van Q', 'nvq@example.com', '123'),
    (N'Nguyen Thi R', 'ntr@example.com', '123'),
    (N'Nguyen Van S', 'nvs@example.com', '123'),
    (N'Nguyen Thi T', 'ntt@example.com', '123'),
    (N'Nguyen Van U', 'nvu@example.com', '123'),
    (N'Nguyen Thi V', 'ntv@example.com', '123'),
    (N'Nguyen Van X', 'nvx@example.com', '123'),
    (N'Nguyen Thi Y', 'nty@example.com', '123'),
    (N'Nguyen Van Z', 'nvz@example.com', '123'),
    (N'Nguyen Thi W', 'ntw@example.com', '123'),
    (N'Nguyen Van D', 'nvd@example.com', '123'),
    (N'Trieu Thach An', 'tta@example.com', '123'),
    (N'Nguyen Van O', 'nvo@example.com', '123'),
    (N'Nguyen Thi O', 'nto@example.com', '123'),
    (N'Nguyen Van P', 'nvp@example.com', '123'),
    (N'Nguyen Thi Q', 'ntq@example.com', '123');
	
	/*
	SELECT * FROM Exams
	DELETE FROM Exams;
	*/
INSERT INTO Exams (ExamID, Title, Description, StartTime, EndTime)
VALUES
    ('ENG01', 'ENG01', 'English Exam 1', '2023-07-01 09:00:00', '2023-07-01 10:30:00'),
    ('ENG02', 'ENG02', 'EN2', '2023-07-02 14:00:00', NULL);

	

	/*
	SELECT * FROM Questions ORDER BY QuestionID ASC
	DELETE FROM Questions;
	*/

	/*
	SELECT * FROM Questions ORDER BY QuestionID ASC
	DELETE FROM Questions WHERE ExamID LIKE 'PRN221';
	*/

	-- English Exam 1
INSERT INTO Questions (ExamID, QuestionID, QuestionText)
VALUES
    ('ENG01', 'ENG01', 'What is the capital of France?'),
    ('ENG01', 'ENG02', 'Who wrote the play "Romeo and Juliet"?'),
    ('ENG01', 'ENG03', 'What is the opposite of "happy"?'),
    ('ENG01', 'ENG04', 'What is the past tense of the verb "go"?'),
    ('ENG01', 'ENG05', 'What is the plural form of "child"?'),
    ('ENG01', 'ENG06', 'What is the synonym of "beautiful"?'),
    ('ENG01', 'ENG07', 'What is the superlative form of "good"?'),
    ('ENG01', 'ENG08', 'What is the correct spelling of the word "receive"?'),
    ('ENG01', 'ENG09', 'What is the meaning of the word "diligent"?'),
    ('ENG01', 'ENG10', 'What is the main language spoken in Australia?');

-- English Exam 2
INSERT INTO Questions (ExamID, QuestionID, QuestionText)
VALUES
    ('ENG02', 'ENG11', 'Who wrote the novel "Pride and Prejudice"?'),
    ('ENG02', 'ENG12', 'What is the plural form of "mouse"?'),
    ('ENG02', 'ENG13', 'What is the opposite of "night"?'),
    ('ENG02', 'ENG14', 'What is the present participle of the verb "run"?'),
    ('ENG02', 'ENG15', 'What is the synonym of "angry"?'),
    ('ENG02', 'ENG16', 'What is the comparative form of "tall"?'),
    ('ENG02', 'ENG17', 'What is the correct spelling of the word "necessary"?'),
    ('ENG02', 'ENG18', 'What is the meaning of the word "confidential"?'),
    ('ENG02', 'ENG19', 'What is the capital of Japan?'),
    ('ENG02', 'ENG20', 'What is the main language spoken in Brazil?');


	/*
	SELECT * FROM Questions ORDER BY QuestionID ASC
	DELETE FROM Options WHERE QuestionID LIKE 'PRN221';
	*/
INSERT INTO Options (QuestionID, OptionText, IsCorrectOption)
VALUES
    ('ENG01', 'Paris', 1),
    ('ENG01', 'London', 0),
    ('ENG01', 'Berlin', 0),
    ('ENG01', 'Madrid', 0),
    ('ENG02', 'William Shakespeare', 1),
    ('ENG02', 'Charles Dickens', 0),
    ('ENG02', 'Jane Austen', 0),
    ('ENG02', 'Mark Twain', 0),
    ('ENG03', 'Sad', 1),
    ('ENG03', 'Angry', 0),
    ('ENG03', 'Excited', 0),
    ('ENG03', 'Joyful', 0),
    ('ENG04', 'Went', 1),
    ('ENG04', 'Gone', 0),
    ('ENG04', 'Been', 0),
    ('ENG04', 'Walked', 0),
    ('ENG05', 'Children', 1),
    ('ENG05', 'Childs', 0),
    ('ENG05', 'Childes', 0),
    ('ENG05', 'Childies', 0),
    ('ENG06', 'Beautiful', 1),
    ('ENG06', 'Ugly', 0),
    ('ENG06', 'Pretty', 0),
    ('ENG06', 'Attractive', 0),
    ('ENG07', 'Best', 1),
    ('ENG07', 'Better', 0),
    ('ENG07', 'Goodest', 0),
    ('ENG07', 'Great', 0),
    ('ENG08', 'Receive', 1),
    ('ENG08', 'Recieve', 0),
    ('ENG08', 'Receeve', 0),
    ('ENG08', 'Recive', 0),
    ('ENG09', 'Hardworking', 1),
    ('ENG09', 'Lazy', 0),
    ('ENG09', 'Intelligent', 0),
    ('ENG09', 'Talented', 0),
    ('ENG10', 'English', 0),
    ('ENG10', 'Spanish', 0),
    ('ENG10', 'French', 0),
    ('ENG10', 'Australian English', 1);

INSERT INTO Options (QuestionID, OptionText, IsCorrectOption)
VALUES
    ('ENG11', 'Jane Austen', 1),
    ('ENG11', 'William Shakespeare', 0),
    ('ENG11', 'Mark Twain', 0),
    ('ENG11', 'Charles Dickens', 0),
    ('ENG12', 'Mice', 1),
    ('ENG12', 'Mouses', 0),
    ('ENG12', 'Meece', 0),
    ('ENG12', 'Mousies', 0),
    ('ENG13', 'Day', 1),
    ('ENG13', 'Morning', 0),
    ('ENG13', 'Sun', 0),
    ('ENG13', 'Bright', 0),
    ('ENG14', 'Running', 1),
    ('ENG14', 'Runned', 0),
    ('ENG14', 'Ran', 0),
    ('ENG14', 'Runing', 0),
    ('ENG15', 'Angry', 1),
    ('ENG15', 'Happy', 0),
    ('ENG15', 'Sad', 0),
    ('ENG15', 'Excited', 0),
    ('ENG16', 'Taller', 1),
    ('ENG16', 'Tallest', 0),
    ('ENG16', 'Tallish', 0),
    ('ENG16', 'Talliest', 0),
    ('ENG17', 'Necessary', 1),
    ('ENG17', 'Neccessary', 0),
    ('ENG17', 'Necessery', 0),
    ('ENG17', 'Necesary', 0),
    ('ENG18', 'Secret', 1),
    ('ENG18', 'Open', 0),
    ('ENG18', 'Public', 0),
    ('ENG18', 'Confused', 0),
    ('ENG19', 'Tokyo', 1),
    ('ENG19', 'Osaka', 0),
    ('ENG19', 'Kyoto', 0),
    ('ENG19', 'Hiroshima', 0),
    ('ENG20', 'Portuguese', 0),
    ('ENG20', 'Spanish', 0),
    ('ENG20', 'English', 0),
    ('ENG20', 'Portuguese', 1);





