--Создание архива 
drop proc if exists CreateArchiveSql;
go

create proc CreateArchiveSql
	as
		begin 
		if object_id('Archive') is null 
		begin
			select * into Archive
			from Repairs
			where Repairs.DateOfCorrection < CONVERT (date, GETDATE());
		end

		else
			begin
			set identity_insert Archive on;
				insert into Archive(Id,IdMalfunction,IdWorker,IdCar,DateOfDetection,DateOfCorrection,IdClient,IsFixed,IdSparePart) 
				select 
					   Id,
					   IdMalfunction,
					   IdWorker,
					   IdCar,
					   DateOfDetection,
					   DateOfCorrection,
					   IdClient,
					   IsFixed,
					   IdSparePart
				from Repairs
				where Repairs.DateOfCorrection < CONVERT (date, GETDATE());
			set identity_insert Archive off;
			end

			delete from Repairs 
			where Repairs.DateOfCorrection < CONVERT (date, GETDATE())
end;
go

exec CreateArchiveSql
go  

--Создание представления рабочие 
drop view if exists ViewWorkers;
go

create view ViewWorkers as
 select 
	Workers.Id,
	People.Surename + ' ' + People.[Name] + ' '+ People.Surename as [FullName],
	Specializations.NameSpecialization as [Specialization],
	Workers.WorkersСategory,
	Workers.Experience

 from Workers join People on Workers.IdPerson = People.Id
			  join Specializations on Workers.IdSpecialization = Specializations.Id
 go

 select * from ViewWorkers

--Создание представления клиенты
drop view if exists ViewClient;
go

create view ViewClient as
 select 
	Clients.Id,
	People.Surename + ' ' + People.[Name] + ' '+ People.Surename as [FullName],
	Clients.Passport,
	Clients.Registration,
	Clients.DateOfBirth

 from Clients join People on Clients.IdPerson = People.Id		  
 go

 select * from ViewClient

--Создание представления архив 
drop view if exists ViewArchive;
go

create view ViewArchive as
 select 
	Archive.Id,
	Malfunctions.NameMalfunction as [Malfunction],
	ViewWorkers.FullName as [Worker],
	ViewWorkers.Specialization,
	CarBrands.NameCarBrand as [CarBrand],
	Cars.StateNumber,
	Archive.DateOfDetection,
	Archive.DateOfCorrection,
	ViewClient.FullName as [Client],
	ViewClient.Passport,
	Archive.IsFixed,
	Malfunctions.Price + SpareParts.Price as [Price]
	

 from Archive join Malfunctions on Archive.IdMalfunction = Malfunctions.Id
			  join ViewWorkers on Archive.IdWorker = ViewWorkers.Id
			  join (Cars join CarBrands on Cars.IdCarBrand = CarBrands.Id) on Cars.Id = Archive.IdCar
			  join ViewClient on Archive.IdClient = ViewClient.Id
			  join SpareParts on Archive.IdSparePart = SpareParts.Id
 go

 select * from ViewArchive

--Запрос 6
--Самая распространенная неисправность в автомобилях указанной марки? 
drop function if exists Query6Sql;
go

create function Query6Sql(@CarBrandId int)
returns table
as 
	return 
		select 
		top (select COUNT(*) from Repairs)
			Malfunctions.NameMalfunction,
			Count(Malfunctions.Id) as [CountMalfunctions]
		from Repairs join Malfunctions on Repairs.IdMalfunction = Malfunctions.Id
					 join (Cars join CarBrands on Cars.IdCarBrand = CarBrands.Id) on Cars.Id = Repairs.IdCar 
		where CarBrands.Id = @CarBrandId
	group by Malfunctions.NameMalfunction
	order by CountMalfunctions
go

select * from Query6Sql(6);
go

--Запрос 7
--Количество рабочих каждой специальности на станции? 
drop proc if exists Query7Sql;
go

create proc Query7Sql
	as
		begin 
			select 
				Specializations.Id,
				Specializations.NameSpecialization,
				Count(Workers.Specialization_Id) as [CountWorkers]
			from Specializations left join Workers on Workers.Specialization_Id = Specializations.Id 
		group by Specializations.Id, Specializations.NameSpecialization
end;
go

exec Query7Sql
go  

--Запрос 8
--Необходимо предусмотреть возможность выдачи справки о количестве автомобилей в ремонте на текущий момент
drop proc if exists Query8Sql;
go

create proc Query8Sql
	as
		begin 
			select DISTINCT
				Repairs.IdCar
			from Repairs 
		where Repairs.IsFixed = 0 and Repairs.DateOfCorrection > CONVERT (date, GETDATE());
	end;
go

exec Query8Sql
go  

--Запрос 9
--количестве незанятых рабочих на текущий момент. --> кол-во раб, которые заняты 

drop proc if exists Query9Sql;
go

create proc Query9Sql
	as
		begin 
			select DISTINCT
				Repairs.IdWorker 
			from Repairs 
		where Repairs.IsFixed = 0 and Repairs.DateOfCorrection > CONVERT (date, GETDATE());
	end;
go

exec Query9Sql
go  

--Запрос 10
--Требуется также выдача месячного отчета о работе станции техобслуживания. В отчет должны войти данные о количестве устраненных неисправностей каждого вида и о доходе, полученном станцией
drop proc if exists Query10Sql;
go

create proc Query10Sql
	@month int
	as
		begin 
			select 
				Malfunctions.Id,
				Malfunctions.NameMalfunction,
				Count(Repairs.IdMalfunction) as [Count],
				Malfunctions.Price*Count(Repairs.IdMalfunction) as  [Profit]
			from Malfunctions left join Repairs on Malfunctions.Id = Repairs.IdMalfunction
			where Repairs.IsFixed = 1 and MONTH(Repairs.DateOfCorrection) = @month
			group by Malfunctions.Id,Malfunctions.NameMalfunction,Malfunctions.Price
	end;
go

exec Query10Sql 8
go  

--Удаление рабочего 
drop proc if exists DropWorkerSql;
go

create proc DropWorkerSql
	@id int
	as 
		begin
			delete from Workers
			where Workers.Id = @id
	end;
go

exec DropWorkerSql 1
go

--Запрос 3
--Перечень устраненных неисправностей в автомобиле данного владельца из архива 
drop proc if exists Query3Sql;
go

create proc Query3Sql
	@id int
	as 
		begin
			select 
				Malfunctions.Id,
				Malfunctions.NameMalfunction,
				Malfunctions.Price
			from Archive join Malfunctions on Archive.IdMalfunction = Malfunctions.Id
			where Archive.IsFixed = 1 and Archive.IdClient = @id
	end;
go

exec Query3Sql 1
go

--Запрос 12
--а также перечень отремонтированных за прошедший месяц и находящихся в ремонте автомобилей, время ремонта каждого автомобиля, список его неисправностей, сведения о работниках, осуществлявших ремонт. 

