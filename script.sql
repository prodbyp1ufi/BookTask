create database BooksDB;


create table Genre(
id serial primary key,
"name" varchar(120) not null
);

create table Author(
id serial primary key,
firstname varchar(120) not null,
lastname varchar(120) not null,
middlename varchar(120)
);

create table Book(
id serial primary key,
"name" varchar(250) not null,
year int not null,
authorId int references Author(Id) not null,
genreId int references Genre(Id) not null
);

insert into genre values (1,'Романтика');
insert into author values (1,'Александр', 'Пушкин', 'Сергеевич');
insert into book  values (1,'Я помню чудное мгновение',1825,1,1);
