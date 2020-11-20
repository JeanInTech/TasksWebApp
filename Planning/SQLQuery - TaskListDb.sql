create database TaskListDb;
use TaskListDb;

create table [User](
Id int primary key identity (1,1) not null,
Email nvarchar(254) not null, 
[Password] nvarchar(128) not null
);

create table ToDo (
Id int primary key identity(1,1) not null,
[Name] nvarchar(30) not null, 
[Description] nvarchar(max) not null,
DueDate DateTime not null,
Completed bit not null
);