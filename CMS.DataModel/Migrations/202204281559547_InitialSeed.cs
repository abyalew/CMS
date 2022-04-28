namespace CMS.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSeed : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Teachers] ON 

                insert into Teachers(Id,Name,Birthday,Salary)

                values
                (1,'Jhon Doe',DATEADD(y,-25, GETDATE()),40000),
                (2,'Jane Doe',DATEADD(y,-27, GETDATE()),40000)

                SET IDENTITY_INSERT [dbo].[Teachers] OFF

                SET IDENTITY_INSERT [dbo].[Subjects] ON 

                Insert into Subjects(Id,Name,CreditPoint,TeacherId)
                values
                (1,'Programming Fundamentals',6,2),
                (2,'Problem Solving',6,1),
                (3,'Data Management and Security',6,1),
                (4,'Object Oriented Design and Programming' ,6,1),
                (5,'Networks and Communications' ,6,2),
                (6,'introduction to web Technology',6,1),
                (7,'Database System',6,1),
                (8,'Advanced Programming',6,2),
                (9,'Mathematics for Computer Science' ,6,1),
                (10,'Aglgorims and Data Structu',6,2),
                (11,'Human Computer inaction',6,1),
                (12,'Software Development Metodologies',6,2)

                SET IDENTITY_INSERT [dbo].[Subjects] OFF

                SET IDENTITY_INSERT [dbo].[Courses] ON 

                Insert into Courses(Id,AwardTitle)
                values (1,'Bachelor of Computer Science')

                SET IDENTITY_INSERT [dbo].[Courses] OFF 

                SET IDENTITY_INSERT [dbo].[CourseSubjects] ON 

                insert into CourseSubjects(Id,CourseId,SubjectId)
                values 
                (1,1,1),
                (2,1,2),
                (3,1,3),
                (4,1,4),
                (5,1,5),
                (6,1,6),
                (7,1,7),
                (8,1,8),
                (9,1,9),
                (10,1,10),
                (11,1,11),
                (12,1,12)

                SET IDENTITY_INSERT [dbo].[CourseSubjects] OFF 

                SET IDENTITY_INSERT [dbo].[Students] ON

                insert into Students(Id,Name,Birthday)
                values
                (1,'Kebrom',DATEADD(y,-20,getdate())),
                (2,'Eliyas',DATEADD(y,-21,getdate())),
                (3,'Ermiyas',DATEADD(y,-23,getdate())),
                (4,'Samrawit',DATEADD(y,-20,getdate()))

                SET IDENTITY_INSERT [dbo].[Students] OFF

                SET IDENTITY_INSERT [dbo].[Admissions] ON

                insert into Admissions(Id,StudentId,CourseId,Grade)
                values 
                (1,1,1,3.16), (2,2,1,2.91), (3,3,1,3.33), (4,4,1,3.33)
                SET IDENTITY_INSERT [dbo].[Admissions] OFF

                SET IDENTITY_INSERT [dbo].[StudentGrades] ON

                insert into StudentGrades(Id,AdmissionId,SubjectId,Grade)
                values 
                (1,1,1,3),
                (2,1,2,3),
                (3,1,3,2),
                (4,1,4,4),
                (5,1,5,3),
                (6,1,6,4),
                (7,1,7,3),
                (8,1,8,4),
                (9,1,9,2),
                (10,1,10,3),
                (11,1,11,4),
                (12,1,12,3),
 
                (13,2,1,3),
                (14,2,2,3),
                (15,2,3,2),
                (16,2,4,2),
                (17,2,5,3),
                (18,2,6,4),
                (19,2,7,3),
                (20,2,8,3),
                (21,2,9,2),
                (22,2,10,3),
                (23,2,11,4),
                (24,2,12,3),

                (25,3,1,3),
                (26,3,2,3),
                (27,3,3,4),
                (28,3,4,4),
                (29,3,5,3),
                (30,3,6,4),
                (31,3,7,3),
                (32,3,8,3),
                (33,3,9,3),
                (34,3,10,3),
                (35,3,11,4),
                (36,3,12,3),

                (37,4,1,3),
                (38,4,2,3),
                (39,4,3,4),
                (40,4,4,4),
                (41,4,5,3),
                (42,4,6,4),
                (43,4,7,2),
                (44,4,8,4),
                (45,4,9,4),
                (46,4,10,2),
                (47,4,11,4),
                (48,4,12,3)


                SET IDENTITY_INSERT [dbo].[StudentGrades] OFF
             ");
        }
        
        public override void Down()
        {
        }
    }
}
