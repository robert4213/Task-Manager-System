Use TaskManagerDB

Insert Into Users(Email,Password,Fullname,MobileNo) Values
('test1@test.com','1234abc','Test1','5105005001'),
('test2@test.com','1234abc','Test2','5105005002'),
('test3@test.com','1234abc','Test3','5105005003'),
('test4@test.com','1234abc','Test4','5105005004'),
('test5@test.com','1234abc','Test5','5105005005')

Insert Into Tasks(UserId,Title,Description,DueDate,Priority,Remarks) Values
(1,'Task1_1','Task1 for User1',DATEADD(day, 20, SYSDATETIME()),'1','This is remarks'),
(1,'Task1_2','Task2 for User1',DATEADD(day, 20, SYSDATETIME()),'2','This is remarks'),
(2,'Task2_1','Task1 for User2',DATEADD(day, 20, SYSDATETIME()),'1','This is remarks'),
(2,'Task2_2','Task2 for User2',DATEADD(day, 20, SYSDATETIME()),'2','This is remarks'),
(3,'Task3_1','Task1 for User3',DATEADD(day, 20, SYSDATETIME()),'1','This is remarks'),
(3,'Task3_2','Task2 for User3',DATEADD(day, 20, SYSDATETIME()),'2','This is remarks'),
(4,'Task4_1','Task1 for User4',DATEADD(day, 20, SYSDATETIME()),'1','This is remarks'),
(4,'Task4_2','Task2 for User4',DATEADD(day, 20, SYSDATETIME()),'2','This is remarks'),
(5,'Task5_1','Task1 for User5',DATEADD(day, 20, SYSDATETIME()),'1','This is remarks'),
(5,'Task5_2','Task2 for User5',DATEADD(day, 20, SYSDATETIME()),'2','This is remarks')