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
				insert into Archive(Id,Malfunction_Id,Worker_Id,Car_Id,DateOfDetection,DateOfCorrection,Client_Id,IsFixed,SparePart_Id) 
				select 
					   Id,
					   Malfunction_Id,
					   Worker_Id,
					   Car_Id,
					   DateOfDetection,
					   DateOfCorrection,
					   Client_Id,
					   IsFixed,
					   SparePart_Id
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

 from Workers join People on Workers.Person_Id = People.Id
			  join Specializations on Workers.Specialization_Id = Specializations.Id
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

 from Clients join People on Clients.Person_Id = People.Id		  
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
	

 from Archive join Malfunctions on Archive.Malfunction_Id = Malfunctions.Id
			  join ViewWorkers on Archive.Worker_Id = ViewWorkers.Id
			  join (Cars join CarBrands on Cars.CarBrand_Id = CarBrands.Id) on Cars.Id = Archive.Car_Id
			  join ViewClient on Archive.Client_Id = ViewClient.Id
			  join SpareParts on Archive.SparePart_Id = SpareParts.Id
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
		from Repairs join Malfunctions on Repairs.Malfunction_Id = Malfunctions.Id
					 join (Cars join CarBrands on Cars.CarBrand_Id = CarBrands.Id) on Cars.Id = Repairs.Car_Id
		where CarBrands.Id = @CarBrandId

	group by Malfunctions.NameMalfunction,CarBrands.NameCarBrand
	order by CountMalfunctions

		union all select 
		
		top (select COUNT(*) from Repairs)
			Malfunctions.NameMalfunction,
			Count(Malfunctions.Id) as [CountMalfunctions]
		from Archive join Malfunctions on Archive.Malfunction_Id = Malfunctions.Id
					 join (Cars join CarBrands on Cars.CarBrand_Id = CarBrands.Id) on Cars.Id = Archive.Car_Id
		where CarBrands.Id = @CarBrandId

	group by Malfunctions.NameMalfunction
	order by CountMalfunctions 
go

select * from Query6Sql(8);
go

select * from Repairs

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
				Count(Repairs.Malfunction_Id) as [Count],
				Malfunctions.Price*Count(Repairs.Malfunction_Id) as  [Profit]
			from Malfunctions left join Repairs on Malfunctions.Id = Repairs.Malfunction_Id
			where Repairs.IsFixed = 1 and MONTH(Repairs.DateOfCorrection) = @month
			group by Malfunctions.Id,Malfunctions.NameMalfunction,Malfunctions.Price

			union select 

				Malfunctions.Id,
				Malfunctions.NameMalfunction,
				Count(Archive.Malfunction_Id) as [Count],
				Malfunctions.Price*Count(Archive.Malfunction_Id) as  [Profit]
			from Malfunctions left join Archive on Malfunctions.Id = Archive.Malfunction_Id
			where Archive.IsFixed = 1 and MONTH(Archive.DateOfCorrection) = @month
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

exec DropWorkerSql 17
go

--Запрос 3
--Перечень устраненных неисправностей в автомобиле данного владельца 
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
			from Archive join Malfunctions on Archive.Malfunction_Id = Malfunctions.Id
						 join Cars on Archive.Car_Id = Cars.Id
			where Archive.IsFixed = 1 and Cars.Client_Id = @id

			union all select

				Malfunctions.Id,
				Malfunctions.NameMalfunction,
				Malfunctions.Price
			from Repairs join Malfunctions on Repairs.Malfunction_Id = Malfunctions.Id
						 join Cars on Repairs.Car_Id = Cars.Id
			where Repairs.IsFixed = 1 and Cars.Client_Id = @id
	end;
go

exec Query3Sql 1
go

--Запрос 4
--Фамилия, имя, отчество работника станции, устранявшего данную неисправность в автомобиле данного клиента, и время ее устранения

drop proc if exists Query4Sql;
go

create proc Query4Sql
	@idClient int,
	@idMalfunctions int
	as 
		begin
			select distinct
					People.[Name],
					People.Surename,
					People.Patronymic,
					ViewWorkers.Specialization,
					Archive.IsFixed,
					Archive.DateOfCorrection

			from Archive join Malfunctions on Archive.Malfunction_Id = Malfunctions.Id
						 join ViewWorkers on Archive.Worker_Id = ViewWorkers.Id
						 join (Workers join People on Workers.Person_Id = People.Id) on Workers.Id = Archive.Worker_Id
			where Archive.Malfunction_Id = @idMalfunctions and Archive.Client_Id = @idClient

			union select distinct

			People.[Name],
					People.Surename,
					People.Patronymic,
					ViewWorkers.Specialization,
					Repairs.IsFixed,
					Repairs.DateOfCorrection

			from Repairs join Malfunctions on Repairs.Malfunction_Id = Malfunctions.Id
						 join ViewWorkers on Repairs.Worker_Id = ViewWorkers.Id
						 join (Workers join People on Workers.Person_Id = People.Id) on Workers.Id = Repairs.Worker_Id
			where Repairs.Malfunction_Id = @idMalfunctions and Repairs.Client_Id = @idClient
	end;
go

exec Query4Sql 1, 1
go

--Запрос 5
--Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным типом неисправности? 
drop proc if exists Query5Sql;
go

create proc Query5Sql
	@idMalfunctions int
	as 
		begin 
			select distinct
					Clients.Id,
					People.[Name],
					People.Surename,
					People.Patronymic,
					Clients.Passport,
					Clients.Registration,
					Clients.DateOfBirth

			from Archive join Malfunctions on Archive.Malfunction_Id = Malfunctions.Id
						 join (Clients join People on Clients.Person_Id = People.Id) on Clients.Id = Archive.Client_Id
			where Archive.Malfunction_Id = @idMalfunctions 

			union select distinct

					Clients.Id,
					People.[Name],
					People.Surename,
					People.Patronymic,
					Clients.Passport,
					Clients.Registration,
					Clients.DateOfBirth

			from Repairs join Malfunctions on Repairs.Malfunction_Id = Malfunctions.Id
						 join (Clients join People on Clients.Person_Id = People.Id) on Clients.Id = Repairs.Client_Id
			where Repairs.Malfunction_Id = @idMalfunctions 
	end;
go

exec Query5Sql 1 
go

--Запрос 12
--а также перечень отремонтированных за прошедший месяц и находящихся в ремонте автомобилей, время ремонта каждого автомобиля, список его неисправностей, сведения о работниках, осуществлявших ремонт. 

