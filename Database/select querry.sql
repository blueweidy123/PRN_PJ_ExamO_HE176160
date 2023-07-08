/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [UserAnswerID]
      ,[UserID]
      ,[ExamID]
      ,[a].[QuestionID]
      ,[SelectedOptionID]
	  ,[o].[IsCorrectOption]
  FROM [OnlineEnExam].[dbo].[UserAnswers] as a LEFT Join [OnlineEnExam].[dbo].[Options] as o on [a].[QuestionID] = [o].[QuestionID]

  SELECT ua.*, o.IsCorrectOption
FROM [OnlineEnExam].[dbo].[UserAnswers] ua
JOIN [OnlineEnExam].[dbo].[Options] o ON ua.SelectedOptionID = o.OptionID

  SELECT * FROM [OnlineEnExam].[dbo].[UserAnswers]

  SELECT * FROM [OnlineEnExam].[dbo].[Results]
  Delete FROM [OnlineEnExam].[dbo].[Results]

  delete from [OnlineEnExam].[dbo].[UserAnswers]