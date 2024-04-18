create database [time_planner]
go

use [time_planner]

create table goals_users(
	id uniqueidentifier,
	login nvarchar(255),
	pass_hash nvarchar(max),
	constraint PK_goals_users primary key (id)
)

create table goals_categories(
	id uniqueidentifier,
	name nvarchar(255),
	[user] uniqueidentifier,
	constraint PK_goals_categories primary key (id),
	constraint FK_goals_categories_user foreign key ([user])
		references goals_users (id)
)

create table goals_periods(
	id uniqueidentifier,
	name nvarchar(255),
	start_date date,
	end_date date,
	[user] uniqueidentifier,
	constraint PK_goals_periods primary key (id),
	constraint FK_goals_periods_user foreign key ([user])
		references goals_users (id)
)

create table goals (
	id uniqueidentifier,
	[name] nvarchar(255),
	[description] nvarchar(255),
	[period] uniqueidentifier ,
	date_set date,
	date_to_complete date null,
	completion_date date null,
	category uniqueidentifier,
	parent uniqueidentifier,
	[user] uniqueidentifier, 
	constraint PK_goals primary key (id),
	constraint FK_categories foreign key (category)
		references goals_categories (id)
		on delete cascade
		on update cascade,
	constraint FK_periods foreign key (period)
		references goals_periods (id)
		on delete cascade
		on update cascade,
	constraint FK_goals_parent foreign key (id)
		references goals (id),
	constraint FK_goals_user foreign key ([user])
		references goals_users (id)
)

create table goals_milestones(
	id uniqueidentifier,
	goal uniqueidentifier,
	completion_date date,
	name nvarchar(255),
	percent_for_completion float,
	constraint PK_goals_milestones primary key (id),
	constraint FK_milestones_goals foreign key (goal)
		references goals (id)
)