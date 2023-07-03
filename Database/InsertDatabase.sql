
USE OnlineExam;

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
    ('PRN221', 'PRN221', 'Basic Cross-Platform Application Programming With .NET', '2023-07-01 09:00:00', '2023-07-01 10:30:00'),
    ('SWP391', 'SWP391', 'Application development project', '2023-07-02 14:00:00', NULL);

	

	/*
	SELECT * FROM Questions
	DELETE FROM Questions;
	*/
INSERT INTO Questions (ExamID, QuestionText)
VALUES
    ('PRN221', '1 + 1 = ?'),
	('PRN221', '123 + 321 = ?'),
	('PRN221', '1 - 1 = ?'),
	('PRN221', '123 + 456 = ?'),
	('PRN221', '987 - 1 = ?'),
	('PRN221', '10 * 11 = ?'),
	('PRN221', '999 / 333 = ?'),
	('PRN221', '0 + 0 = ?'),
	('PRN221', '12345 + 56789 = ?'),
	('PRN221', '987 - 654 = ?');


	