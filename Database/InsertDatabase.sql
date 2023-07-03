
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
	SELECT * FROM Questions ORDER BY QuestionID ASC
	DELETE FROM Questions;
	*/

	/*
	SELECT * FROM Questions ORDER BY QuestionID ASC
	DELETE FROM Questions WHERE ExamID LIKE 'PRN221';
	*/
INSERT INTO Questions (ExamID, QuestionID, QuestionText)
VALUES
    ('PRN221', 'PRN01', 'What is the result of 9 + 6?'),
    ('PRN221', 'PRN02', 'Solve: 4 * 5 - 3.'),
    ('PRN221', 'PRN03', 'Calculate: 20 / 4 + 2.'),
    ('PRN221', 'PRN04', 'Find the value of 5 cubed.'),
    ('PRN221', 'PRN05', 'Evaluate: 12 - 6 * 3.'),
    ('PRN221', 'PRN06', 'Simplify: 2 + 4 * 2.'),
    ('PRN221', 'PRN07', 'Compute: 8 * 7 / 4.'),
    ('PRN221', 'PRN08', 'What is the square root of 144?'),
    ('PRN221', 'PRN09', 'Evaluate: 16 - 3 + 5.'),
    ('PRN221', 'PRN10', 'Solve: 3 * (6 + 2) - 4.');


INSERT INTO Questions (ExamID, QuestionID, QuestionText)
VALUES
    ('SWP391', 'SWP01', 'What is the result of 2 + 2?'),
    ('SWP391', 'SWP02', 'Solve: 5 * 3 - 7.'),
    ('SWP391', 'SWP03', 'Calculate: 10 / 2 + 3.'),
    ('SWP391', 'SWP04', 'Find the value of 8 squared.'),
    ('SWP391', 'SWP05', 'Evaluate: 15 - 4 * 2.'),
    ('SWP391', 'SWP06', 'Simplify: 3 + 2 * 4.'),
    ('SWP391', 'SWP07', 'Compute: 7 * 6 / 3.'),
    ('SWP391', 'SWP08', 'What is the square root of 64?'),
    ('SWP391', 'SWP09', 'Evaluate: 12 - 5 + 8.'),
    ('SWP391', 'SWP10', 'Solve: 2 * (4 + 3) - 5.');


	/*
	SELECT * FROM Options
	DELETE FROM Options
	*/
INSERT INTO Options (QuestionID, OptionText, IsCorrectOption)
VALUES
    ('PRN01', '3', 0),
    ('PRN01', '5', 0),
    ('PRN01', '7', 0),
    ('PRN01', '15', 1),
    ('PRN02', '12', 0),
    ('PRN02', '17', 0),
    ('PRN02', '18', 0),
    ('PRN02', '19', 1),
    ('PRN03', '4', 0),
    ('PRN03', '7', 0),
    ('PRN03', '9', 0),
    ('PRN03', '12', 1),
    ('PRN04', '125', 0),
    ('PRN04', '256', 1),
    ('PRN04', '512', 0),
    ('PRN04', '729', 0),
    ('PRN05', '6', 0),
    ('PRN05', '18', 0),
    ('PRN05', '24', 1),
    ('PRN05', '30', 0),
    ('PRN06', '9', 0),
    ('PRN06', '11', 0),
    ('PRN06', '13', 1),
    ('PRN06', '15', 0),
    ('PRN07', '12', 0),
    ('PRN07', '14', 0),
    ('PRN07', '16', 1),
    ('PRN07', '18', 0),
    ('PRN08', '8', 0),
    ('PRN08', '10', 0),
    ('PRN08', '12', 0),
    ('PRN08', '16', 1),
    ('PRN09', '8', 0),
    ('PRN09', '10', 0),
    ('PRN09', '13', 0),
    ('PRN09', '21', 1),
    ('PRN10', '14', 0),
    ('PRN10', '18', 0),
    ('PRN10', '20', 1),
    ('PRN10', '24', 0);

INSERT INTO Options (QuestionID, OptionText, IsCorrectOption)
VALUES
    ('SWP01', '2', 0),
    ('SWP01', '3', 0),
    ('SWP01', '4', 1),
    ('SWP01', '5', 0),
    ('SWP02', '8', 0),
    ('SWP02', '12', 1),
    ('SWP02', '15', 0),
    ('SWP02', '17', 0),
    ('SWP03', '6', 0),
    ('SWP03', '8', 0),
    ('SWP03', '10', 1),
    ('SWP03', '12', 0),
    ('SWP04', '32', 0),
    ('SWP04', '64', 1),
    ('SWP04', '128', 0),
    ('SWP04', '256', 0),
    ('SWP05', '5', 0),
    ('SWP05', '7', 0),
    ('SWP05', '11', 1),
    ('SWP05', '17', 0),
    ('SWP06', '9', 0),
    ('SWP06', '11', 1),
    ('SWP06', '13', 0),
    ('SWP06', '15', 0),
    ('SWP07', '10', 0),
    ('SWP07', '14', 1),
    ('SWP07', '18', 0),
    ('SWP07', '21', 0),
    ('SWP08', '6', 0),
    ('SWP08', '8', 0),
    ('SWP08', '10', 0),
    ('SWP08', '16', 1),
    ('SWP09', '7', 0),
    ('SWP09', '11', 1),
    ('SWP09', '15', 0),
    ('SWP09', '18', 0),
    ('SWP10', '10', 0),
    ('SWP10', '12', 1),
    ('SWP10', '15', 0),
    ('SWP10', '17', 0);



