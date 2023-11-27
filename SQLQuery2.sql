CREATE DATABASE BlogsDB
USE BlogsDB

CREATE TABLE Users 
(
	Id int identity primary key,
	Name nvarchar(15),
	Surname nvarchar(20),
	Username nvarchar(15),
	Password nvarchar(16),
)

CREATE TABLE Blogs
(
	Id int identity primary key,
	Title nvarchar(150),
	Description nvarchar(max),
	UserId int references Users(Id)
)

INSERT INTO Users VALUES (N'Gunash', N'Mammadli', N'GunashMamm', N'Gunash123');
INSERT INTO Users VALUES (N'Ali', N'Afandiyev', N'AliAfandi', N'Ali12345');
INSERT INTO Users VALUES (N'Kenan', N'Aliyev', N'KenanAli', N'Kenan123');
INSERT INTO Users VALUES (N'Zaur', N'Ibrahimov', N'ZaurIbrahim', N'Zaur12345');

INSERT INTO Blogs VALUES (N'Shaki', N'ShakiAze', 1);
INSERT INTO Blogs VALUES (N'Baku', N'BakuAze', 2);
INSERT INTO Blogs VALUES (N'Krakow', N'KrakowPl', 1);
INSERT INTO Blogs VALUES (N'Kabala', N'KabalaAze', 3);



