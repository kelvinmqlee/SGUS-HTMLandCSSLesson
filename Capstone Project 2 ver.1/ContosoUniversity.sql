USE [ContosoUniversity(CapstoneProject2)]
GO
/****** Object:  Table [dbo].[tblCourseInstructor]    Script Date: 01/18/2021 3:24:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourseInstructor](
	[CourseId] [int] NOT NULL,
	[InstructorId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCourses]    Script Date: 01/18/2021 3:24:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCourses](
	[CourseId] [int] NOT NULL,
	[Title] [varchar](300) NOT NULL,
	[Credits] [tinyint] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_tblCourses] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblDepartments]    Script Date: 01/18/2021 3:24:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblDepartments](
	[DepartmentId] [int] NOT NULL,
	[Name] [varchar](300) NOT NULL,
	[Budget] [money] NULL,
	[AdministratorId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
 CONSTRAINT [PK_tblDepartments] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEnrollment]    Script Date: 01/18/2021 3:24:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEnrollment](
	[EnrollmentId] [int] NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Grade] [char](1) NOT NULL,
 CONSTRAINT [PK_tblEnrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblInstructors]    Script Date: 01/18/2021 3:24:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblInstructors](
	[InstructorId] [int] NOT NULL,
	[FirstName] [varchar](300) NOT NULL,
	[LastName] [varchar](300) NOT NULL,
	[HireDate] [date] NOT NULL,
 CONSTRAINT [PK_tblInstructors] PRIMARY KEY CLUSTERED 
(
	[InstructorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblStudents]    Script Date: 01/18/2021 3:24:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblStudents](
	[StudentId] [int] NOT NULL,
	[FirstName] [varchar](300) NOT NULL,
	[LastName] [varchar](300) NOT NULL,
	[EnrollmentDate] [date] NOT NULL,
 CONSTRAINT [PK_tblStudents] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblCourseInstructor] ([CourseId], [InstructorId]) VALUES (1, 1)
GO
INSERT [dbo].[tblCourseInstructor] ([CourseId], [InstructorId]) VALUES (2, 2)
GO
INSERT [dbo].[tblCourseInstructor] ([CourseId], [InstructorId]) VALUES (3, 3)
GO
INSERT [dbo].[tblCourseInstructor] ([CourseId], [InstructorId]) VALUES (4, 1)
GO
INSERT [dbo].[tblCourses] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (1, N'Poetry', 2, 1)
GO
INSERT [dbo].[tblCourses] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (2, N'Physics', 4, 2)
GO
INSERT [dbo].[tblCourses] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (3, N'Microeconomics', 3, 3)
GO
INSERT [dbo].[tblCourses] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (4, N'Literature', 4, 1)
GO
INSERT [dbo].[tblCourses] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (5, N'FSD', 5, 2)
GO
INSERT [dbo].[tblCourses] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (6, N'JS', 1, 3)
GO
INSERT [dbo].[tblCourses] ([CourseId], [Title], [Credits], [DepartmentId]) VALUES (7, N'C#', 0, 4)
GO
INSERT [dbo].[tblDepartments] ([DepartmentId], [Name], [Budget], [AdministratorId], [StartDate]) VALUES (1, N'English', 5000.0000, 1, CAST(N'2020-10-01' AS Date))
GO
INSERT [dbo].[tblDepartments] ([DepartmentId], [Name], [Budget], [AdministratorId], [StartDate]) VALUES (2, N'STEM', 5000.0000, 2, CAST(N'2020-10-01' AS Date))
GO
INSERT [dbo].[tblDepartments] ([DepartmentId], [Name], [Budget], [AdministratorId], [StartDate]) VALUES (3, N'Economics', 5000.0000, 3, CAST(N'2020-10-01' AS Date))
GO
INSERT [dbo].[tblDepartments] ([DepartmentId], [Name], [Budget], [AdministratorId], [StartDate]) VALUES (4, N'SQL', 10000.0000, 4, CAST(N'2021-01-18' AS Date))
GO
INSERT [dbo].[tblDepartments] ([DepartmentId], [Name], [Budget], [AdministratorId], [StartDate]) VALUES (5, N'C#', 10000.0000, 5, CAST(N'2021-01-18' AS Date))
GO
INSERT [dbo].[tblDepartments] ([DepartmentId], [Name], [Budget], [AdministratorId], [StartDate]) VALUES (6, N'JS', 8000.0000, 6, CAST(N'2021-01-18' AS Date))
GO
INSERT [dbo].[tblEnrollment] ([EnrollmentId], [StudentId], [CourseId], [Grade]) VALUES (1, 1, 1, N'A')
GO
INSERT [dbo].[tblEnrollment] ([EnrollmentId], [StudentId], [CourseId], [Grade]) VALUES (2, 2, 2, N'B')
GO
INSERT [dbo].[tblEnrollment] ([EnrollmentId], [StudentId], [CourseId], [Grade]) VALUES (3, 3, 3, N'C')
GO
INSERT [dbo].[tblEnrollment] ([EnrollmentId], [StudentId], [CourseId], [Grade]) VALUES (4, 4, 4, N'D')
GO
INSERT [dbo].[tblEnrollment] ([EnrollmentId], [StudentId], [CourseId], [Grade]) VALUES (5, 5, 5, N'E')
GO
INSERT [dbo].[tblEnrollment] ([EnrollmentId], [StudentId], [CourseId], [Grade]) VALUES (6, 6, 6, N'F')
GO
INSERT [dbo].[tblInstructors] ([InstructorId], [FirstName], [LastName], [HireDate]) VALUES (1, N'Kim', N'Abercrombie', CAST(N'2020-10-01' AS Date))
GO
INSERT [dbo].[tblInstructors] ([InstructorId], [FirstName], [LastName], [HireDate]) VALUES (2, N'Roger', N'Harui', CAST(N'2020-10-01' AS Date))
GO
INSERT [dbo].[tblInstructors] ([InstructorId], [FirstName], [LastName], [HireDate]) VALUES (3, N'Stacy', N'Serrano', CAST(N'2020-10-01' AS Date))
GO
INSERT [dbo].[tblInstructors] ([InstructorId], [FirstName], [LastName], [HireDate]) VALUES (4, N'Shiv', N'Koi', CAST(N'2021-01-18' AS Date))
GO
INSERT [dbo].[tblInstructors] ([InstructorId], [FirstName], [LastName], [HireDate]) VALUES (5, N'Kelvin', N'Lee', CAST(N'2021-01-18' AS Date))
GO
INSERT [dbo].[tblInstructors] ([InstructorId], [FirstName], [LastName], [HireDate]) VALUES (6, N'Tester', N'123', CAST(N'2021-01-18' AS Date))
GO
INSERT [dbo].[tblStudents] ([StudentId], [FirstName], [LastName], [EnrollmentDate]) VALUES (1, N'Peggy', N'Justice', CAST(N'2020-10-01' AS Date))
GO
INSERT [dbo].[tblStudents] ([StudentId], [FirstName], [LastName], [EnrollmentDate]) VALUES (2, N'Yan', N'Li', CAST(N'2020-10-01' AS Date))
GO
INSERT [dbo].[tblStudents] ([StudentId], [FirstName], [LastName], [EnrollmentDate]) VALUES (3, N'Laura', N'Norman', CAST(N'2020-10-01' AS Date))
GO
INSERT [dbo].[tblStudents] ([StudentId], [FirstName], [LastName], [EnrollmentDate]) VALUES (4, N'Shiv', N'Koi', CAST(N'2021-01-18' AS Date))
GO
INSERT [dbo].[tblStudents] ([StudentId], [FirstName], [LastName], [EnrollmentDate]) VALUES (5, N'Kelvin', N'Lee', CAST(N'2021-01-18' AS Date))
GO
INSERT [dbo].[tblStudents] ([StudentId], [FirstName], [LastName], [EnrollmentDate]) VALUES (6, N'Tester', N'123', CAST(N'2021-01-18' AS Date))
GO
ALTER TABLE [dbo].[tblCourses] ADD  CONSTRAINT [DF_tblCourses_Credits]  DEFAULT ((0)) FOR [Credits]
GO
ALTER TABLE [dbo].[tblCourseInstructor]  WITH CHECK ADD  CONSTRAINT [FK_tblCourseInstructor_tblCourses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[tblCourses] ([CourseId])
GO
ALTER TABLE [dbo].[tblCourseInstructor] CHECK CONSTRAINT [FK_tblCourseInstructor_tblCourses]
GO
ALTER TABLE [dbo].[tblCourseInstructor]  WITH CHECK ADD  CONSTRAINT [FK_tblCourseInstructor_tblInstructors] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[tblInstructors] ([InstructorId])
GO
ALTER TABLE [dbo].[tblCourseInstructor] CHECK CONSTRAINT [FK_tblCourseInstructor_tblInstructors]
GO
ALTER TABLE [dbo].[tblEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_tblEnrollment_tblCourses] FOREIGN KEY([CourseId])
REFERENCES [dbo].[tblCourses] ([CourseId])
GO
ALTER TABLE [dbo].[tblEnrollment] CHECK CONSTRAINT [FK_tblEnrollment_tblCourses]
GO
ALTER TABLE [dbo].[tblEnrollment]  WITH CHECK ADD  CONSTRAINT [FK_tblEnrollment_tblStudents] FOREIGN KEY([StudentId])
REFERENCES [dbo].[tblStudents] ([StudentId])
GO
ALTER TABLE [dbo].[tblEnrollment] CHECK CONSTRAINT [FK_tblEnrollment_tblStudents]
GO
ALTER TABLE [dbo].[tblInstructors]  WITH CHECK ADD  CONSTRAINT [FK_tblInstructors_tblDepartments] FOREIGN KEY([InstructorId])
REFERENCES [dbo].[tblDepartments] ([AdministratorId])
GO
ALTER TABLE [dbo].[tblInstructors] CHECK CONSTRAINT [FK_tblInstructors_tblDepartments]
GO
ALTER TABLE [dbo].[tblCourses]  WITH CHECK ADD  CONSTRAINT [CK_tblCourses] CHECK  (([Credits]<=(5)))
GO
ALTER TABLE [dbo].[tblCourses] CHECK CONSTRAINT [CK_tblCourses]
GO
ALTER TABLE [dbo].[tblEnrollment]  WITH CHECK ADD  CONSTRAINT [CK_tblEnrollment] CHECK  (([Grade] like '[A-F]'))
GO
ALTER TABLE [dbo].[tblEnrollment] CHECK CONSTRAINT [CK_tblEnrollment]
GO
