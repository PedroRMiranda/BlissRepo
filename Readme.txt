Bliss Recruitment App - Pedro Miranda
Back-end 

SQL Commands to setup Database

----
CREATE DATABASE ApiDemo
GO 
----

----
CREATE TABLE dbo.Questions
   (ID INT PRIMARY KEY NOT NULL,  
    Question NVARCHAR(1000) NOT NULL,  
    Image_url NVARCHAR(2083) NOT NULL,  
    Thumb_url NVARCHAR(2083) NOT NULL,
    Published_at DATETIME NOT NULL)  
GO  
----

----
CREATE TABLE dbo.Choices
   (ID INT PRIMARY KEY NOT NULL,  
    QuestionID INT NOT NULL,  
    Choice NVARCHAR(1000) NOT NULL,  
    Votes INT NOT NULL)  
GO  
----



