USE [ProjectFinal]
GO
/****** Object:  Table [dbo].[Lectures]    Script Date: 12/01/2020 12:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lectures](
	[LecID] [int] NOT NULL,
	[LecName] [varchar](50) NOT NULL,
	[LeclastName] [varchar](50) NULL,
 CONSTRAINT [PK_Lectures] PRIMARY KEY CLUSTERED 
(
	[LecID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentInCourse]    Script Date: 12/01/2020 12:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentInCourse](
	[StudentID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
	[GradeA] [int] NULL,
	[GradeB] [int] NULL,
 CONSTRAINT [PK_StudentInCourse] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 12/01/2020 12:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseID] [int] NOT NULL,
	[LectureID] [int] NOT NULL,
	[Coursename] [varchar](50) NOT NULL,
	[Day] [varchar](50) NOT NULL,
	[StartHour] [time](7) NOT NULL,
	[EndHour] [time](7) NULL,
	[moedAClass] [varchar](50) NULL,
	[moedBClass] [varchar](50) NULL,
	[ExamDay] [varchar](50) NULL,
	[ExamHour] [time](7) NULL,
	[moedAYear] [int] NULL,
	[moedAMonth] [int] NULL,
	[moedADay] [int] NULL,
	[moedBYear] [int] NULL,
	[moedBMonth] [int] NULL,
	[moedBDay] [int] NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Student_Schedule_Course_Exam]    Script Date: 12/01/2020 12:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Student_Schedule_Course_Exam]
AS
SELECT dbo.Lectures.LecName, dbo.StudentInCourse.StudentID, dbo.Courses.CourseID, dbo.Courses.Coursename, dbo.Courses.Day, dbo.Lectures.LeclastName, dbo.Courses.moedAClass, dbo.Courses.moedBClass, dbo.Courses.ExamDay, 
                  dbo.Courses.ExamHour, dbo.Courses.StartHour, dbo.Courses.EndHour, dbo.Courses.moedBDay, dbo.Courses.moedBMonth, dbo.Courses.moedBYear, dbo.Courses.moedADay, dbo.Courses.moedAMonth, dbo.Courses.moedAYear, 
                  dbo.StudentInCourse.GradeB, dbo.StudentInCourse.GradeA
FROM     dbo.Courses INNER JOIN
                  dbo.StudentInCourse ON dbo.Courses.CourseID = dbo.StudentInCourse.CourseID CROSS JOIN
                  dbo.Lectures
GO
/****** Object:  View [dbo].[LectureCourses]    Script Date: 12/01/2020 12:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[LectureCourses]
AS
SELECT dbo.Lectures.LecID, dbo.Courses.CourseID, dbo.Courses.Coursename, dbo.Courses.Day, dbo.Courses.StartHour, dbo.Courses.EndHour
FROM  dbo.Courses CROSS JOIN
         dbo.Lectures
GO
/****** Object:  Table [dbo].[Students]    Script Date: 12/01/2020 12:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [int] NOT NULL,
	[studentName] [varchar](50) NOT NULL,
	[studentlastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Editcourse]    Script Date: 12/01/2020 12:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Editcourse]
AS
SELECT dbo.Students.studentName, dbo.Students.studentlastName, dbo.StudentInCourse.StudentID, dbo.Courses.CourseID, dbo.Courses.Coursename, dbo.Courses.LectureID, dbo.StudentInCourse.GradeB, dbo.StudentInCourse.GradeA
FROM     dbo.Courses INNER JOIN
                  dbo.StudentInCourse ON dbo.Courses.CourseID = dbo.StudentInCourse.CourseID INNER JOIN
                  dbo.Students ON dbo.StudentInCourse.StudentID = dbo.Students.StudentID
GO
/****** Object:  Table [dbo].[Facultys]    Script Date: 12/01/2020 12:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facultys](
	[FacultyID] [int] NOT NULL,
	[facfirstName] [varchar](50) NOT NULL,
	[faclastName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Facultys] PRIMARY KEY CLUSTERED 
(
	[FacultyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 12/01/2020 12:07:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[userID] [int] NOT NULL,
	[userName] [varchar](50) NOT NULL,
	[userPassword] [varchar](50) NOT NULL,
	[userType] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[userID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Facultys]  WITH CHECK ADD  CONSTRAINT [FK_Facultys_Users] FOREIGN KEY([FacultyID])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Facultys] CHECK CONSTRAINT [FK_Facultys_Users]
GO
ALTER TABLE [dbo].[Lectures]  WITH CHECK ADD  CONSTRAINT [FK_Lectures_Users] FOREIGN KEY([LecID])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Lectures] CHECK CONSTRAINT [FK_Lectures_Users]
GO
ALTER TABLE [dbo].[StudentInCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentInCourse_Courses] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Courses] ([CourseID])
GO
ALTER TABLE [dbo].[StudentInCourse] CHECK CONSTRAINT [FK_StudentInCourse_Courses]
GO
ALTER TABLE [dbo].[StudentInCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentInCourse_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[StudentInCourse] CHECK CONSTRAINT [FK_StudentInCourse_Students]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Users] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Users] ([userID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Users]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Courses"
            Begin Extent = 
               Top = 15
               Left = 96
               Bottom = 324
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "StudentInCourse"
            Begin Extent = 
               Top = 15
               Left = 520
               Bottom = 281
               Right = 848
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Students"
            Begin Extent = 
               Top = 15
               Left = 944
               Bottom = 281
               Right = 1300
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Editcourse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Editcourse'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Courses"
            Begin Extent = 
               Top = 15
               Left = 96
               Bottom = 418
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Lectures"
            Begin Extent = 
               Top = 15
               Left = 520
               Bottom = 281
               Right = 848
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LectureCourses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LectureCourses'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Courses"
            Begin Extent = 
               Top = 15
               Left = 96
               Bottom = 612
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "StudentInCourse"
            Begin Extent = 
               Top = 15
               Left = 944
               Bottom = 383
               Right = 1272
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Lectures"
            Begin Extent = 
               Top = 15
               Left = 520
               Bottom = 355
               Right = 848
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1596
         Alias = 900
         Table = 1176
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1356
         SortOrder = 1416
         GroupBy = 1350
         Filter = 1356
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Student_Schedule_Course_Exam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Student_Schedule_Course_Exam'
GO
