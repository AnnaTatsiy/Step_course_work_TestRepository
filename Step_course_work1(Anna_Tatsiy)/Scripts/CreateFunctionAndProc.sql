------------------------------------------------------------------------------------------------------------------------------------------------------//
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
------------------------------------------------------------------------------------------------------------------------------------------------------//
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

------------------------------------------------------------------------------------------------------------------------------------------------------//
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

------------------------------------------------------------------------------------------------------------------------------------------------------//
 --Создание представления авто
drop view if exists ViewCars;
go

create view ViewCars as
 select 
	Cars.Id,
	CarBrands.Id as [CarBrandsId],
	CarBrands.NameCarBrand as [CarBrand],
	Colors.Id as [ColorsId], 
	Colors.NameColor as [Color],
	Cars.YearOfRelease,
	Cars.StateNumber,
	ViewClient.Id as [OwnerId],
	ViewClient.FullName as [Owner],
	ViewClient.Passport as [OwnerPassport]

 from Cars join CarBrands on Cars.CarBrand_Id = CarBrands.Id
		   join Colors on Cars.Color_Id = Colors.Id
		   Join ViewClient on Cars.Client_Id = ViewClient.Id
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
--Создание представления архив 
drop view if exists ViewArchive;
go

create view ViewArchive as
 select 
	Archive.Id,
	Malfunctions.Id as [MalfunctionId],
	Malfunctions.NameMalfunction as [Malfunction],
	Malfunctions.Price as [MalfunctionsPrice],
	ViewWorkers.Id as [WorkersId],
	ViewWorkers.FullName as [Worker],
	ViewWorkers.Specialization,
	ViewCars.Id as [CarsId],
	ViewCars.CarBrand,
	ViewCars.StateNumber,
	Archive.DateOfDetection,
	Archive.DateOfCorrection,
	ViewClient.Id as [ClientId],
	ViewClient.FullName as [Client],
	ViewClient.Passport,
	Archive.IsFixed,
	SpareParts.Id as [SparePartsId],
	SpareParts.NameSparePart as [SparePart],
	SpareParts.Price as [SparePartPrice],
	Malfunctions.Price + SpareParts.Price as [Price]
	

 from Archive join Malfunctions on Archive.Malfunction_Id = Malfunctions.Id
			  join ViewWorkers on Archive.Worker_Id = ViewWorkers.Id
			  join ViewCars on ViewCars.Id = Archive.Car_Id
			  join ViewClient on Archive.Client_Id = ViewClient.Id
			  join SpareParts on Archive.SparePart_Id = SpareParts.Id
 go

------------------------------------------------------------------------------------------------------------------------------------------------------//
 --представление ремонты 

drop view if exists ViewRepairs;
go

create view ViewRepairs as
 select 
	Repairs.Id,
	Malfunctions.Id as [MalfunctionId],
	Malfunctions.NameMalfunction as [Malfunction],
	Malfunctions.Price as [MalfunctionsPrice],
	ViewWorkers.Id as [WorkersId],
	ViewWorkers.FullName as [Worker],
	ViewWorkers.Specialization,
	ViewCars.Id as [CarsId],
	ViewCars.CarBrand,
	ViewCars.StateNumber,
	Repairs.DateOfDetection,
	Repairs.DateOfCorrection,
	ViewClient.Id as [ClientId],
	ViewClient.FullName as [Client],
	ViewClient.Passport,
	Repairs.IsFixed,
	SpareParts.Id as [SparePartId],
	SpareParts.NameSparePart as [SparePart],
	SpareParts.Price as [SparePartPrice],
	Malfunctions.Price + SpareParts.Price as [Price]
	

 from Repairs join Malfunctions on Repairs.Malfunction_Id = Malfunctions.Id
			  join ViewWorkers on Repairs.Worker_Id = ViewWorkers.Id
			  join ViewCars on ViewCars.Id = Repairs.Car_Id
			  join ViewClient on Repairs.Client_Id = ViewClient.Id
			  join SpareParts on Repairs.SparePart_Id = SpareParts.Id
 go

------------------------------------------------------------------------------------------------------------------------------------------------------//
--Запрос 1
--Фамилия, имя, отчество и адрес владельца автомобиля с данным номером государственной регистрации

drop proc if exists Query1Sql;
go

create proc Query1Sql
	@id int 
	as
		begin 
			select 
				ViewClient.Id,
				ViewClient.FullName,
				ViewClient.Passport,
				ViewClient.Registration,
				ViewClient.DateOfBirth

			from ViewCars join ViewClient on ViewCars.OwnerId = ViewClient.Id
		where ViewCars.Id = @id
end;
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
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
		
		top (select COUNT(*) from Archive)
			Malfunctions.NameMalfunction,
			Count(Malfunctions.Id) as [CountMalfunctions]
		from Archive join Malfunctions on Archive.Malfunction_Id = Malfunctions.Id
					 join (Cars join CarBrands on Cars.CarBrand_Id = CarBrands.Id) on Cars.Id = Archive.Car_Id
		where CarBrands.Id = @CarBrandId

	group by Malfunctions.NameMalfunction
	order by CountMalfunctions 
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
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
 
------------------------------------------------------------------------------------------------------------------------------------------------------//
--Запрос 10
--Требуется также выдача месячного отчета о работе станции техобслуживания. В отчет должны войти данные о количестве устраненных неисправностей каждого вида и о доходе, полученном станцией
drop function if exists Query10Sql;
go

create function Query10Sql(@month int)
	returns table
	as
		return
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
	--end;
go

------------------------------------------------------------------------------------------------------------------------------------------------------// 
drop proc if exists Proc10Sql;
go

create proc Proc10Sql
@month int
	as
		begin 
		drop table if exists Query10Sql_copy;
		select * into  Query10Sql_copy
			from  Query10Sql(@month)

			select distinct 
				Id,
				NameMalfunction,
				Sum([Count]) as [Count],
				Sum([Profit]) as [Profit]
			
			from Query10Sql_copy
			group by Id,NameMalfunction
			drop table Query10Sql_copy;
	end;
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
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

------------------------------------------------------------------------------------------------------------------------------------------------------//
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

------------------------------------------------------------------------------------------------------------------------------------------------------//
--Запрос 4
--Фамилия, имя, отчество работника станции, устранявшего данную неисправность в автомобиле данного клиента, и время ее устранения

drop proc if exists Query4Sql;
go

create proc Query4Sql
	@idClient int,
	@idMalfunctions int
	as 
		begin
			select 
					ViewWorkers.FullName,
					ViewWorkers.Specialization,
					Archive.IsFixed,
					Archive.DateOfCorrection

			from Archive join Malfunctions on Archive.Malfunction_Id = Malfunctions.Id
						 join ViewWorkers on Archive.Worker_Id = ViewWorkers.Id
			where Archive.Malfunction_Id = @idMalfunctions and Archive.Client_Id = @idClient

			union select 

					ViewWorkers.FullName,
					ViewWorkers.Specialization,
					Repairs.IsFixed,
					Repairs.DateOfCorrection

			from Repairs join Malfunctions on Repairs.Malfunction_Id = Malfunctions.Id
						 join ViewWorkers on Repairs.Worker_Id = ViewWorkers.Id
			where Repairs.Malfunction_Id = @idMalfunctions and Repairs.Client_Id = @idClient
	end;
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
--Запрос 5
--Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным типом неисправности? 
drop proc if exists Query5Sql;
go

create proc Query5Sql
	@idMalfunctions int
	as 
		begin 
			select distinct
					ViewClient.Id,
					ViewClient.FullName,
					ViewClient.Passport,
					ViewClient.Registration,
					ViewClient.DateOfBirth

			from Archive join Malfunctions on Archive.Malfunction_Id = Malfunctions.Id
						 join ViewClient  on ViewClient.Id = Archive.Client_Id
			where Archive.Malfunction_Id = @idMalfunctions 

			union select distinct

					ViewClient.Id,
					ViewClient.FullName,
					ViewClient.Passport,
					ViewClient.Registration,
					ViewClient.DateOfBirth

			from Repairs join Malfunctions on Repairs.Malfunction_Id = Malfunctions.Id
						 join ViewClient on ViewClient.Id = Repairs.Client_Id
			where Repairs.Malfunction_Id = @idMalfunctions 
	end;
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
--Запрос 12
--клиент получает счет, в котором содержится перечень устраненных неисправностей с указанием времени работы, стоимости работы и стоимости запчастей. 
drop proc if exists Query12Sql;
go

create proc Query12Sql
	@idCar int,
	@idClient int
	as 
		begin 
			select 
				* 
			from ViewArchive
			where ViewArchive.ClientId = @idClient and ViewArchive.CarsId = @idCar
	end;
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
--Запрос 13
--клиент получает расписку, в которой указано, когда автомобиль был поставлен на ремонт, какие он имеет неисправности, когда станция обязуется возвратить 
--отремонтированный автомобиль.  
drop proc if exists Query13Sql;
go

create proc Query13Sql
	@idCar int,
	@idClient int
	as 
		begin 
			select 
				* 
			from ViewRepairs
			where ViewRepairs.ClientId = @idClient and ViewRepairs.CarsId = @idCar
	end;
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
--изменение сведений о клиенте (клиент может поменять паспорт, адрес), 
drop proc if exists EditClientSql;
go

create proc EditClientSql
	@idClient int,
	@newPassport nvarchar(11),
	@newRegistration nvarchar(255)
	as 
		begin 
			update Clients
			set Passport = @newPassport,
			Registration = @newRegistration

			where Clients.Id = @idClient 
	end;
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
--номера государственной регистрации и цвета автомобиля. 
drop proc if exists EditCarSql;
go

create proc EditCarSql
	@idCar int,
	@newStateNumber nvarchar(20),
	@idColor int
	as 
		begin 
			update Cars
			set StateNumber = @newStateNumber,
			Color_Id = @idColor

			where Cars.Id = @idCar
	end;
go

------------------------------------------------------------------------------------------------------------------------------------------------------//
--перечень отремонтированных за прошедший месяц и находящихся в ремонте автомобилей
--время ремонта каждого автомобиля, список его неисправностей, сведения о работниках, осуществлявших ремонт.
drop function if exists Query14Sql;
go

create function Query14Sql()
	returns table
	as
		return
			select 
				ViewRepairs.Id,
				ViewRepairs.CarsId,
				ViewRepairs.CarBrand,
				ViewRepairs.StateNumber,
				ViewRepairs.Malfunction,
				ViewRepairs.Worker,
				ViewRepairs.IsFixed,
				ViewRepairs.DateOfDetection,
				ViewRepairs.DateOfCorrection
			from ViewRepairs
			where MONTH(ViewRepairs.DateOfDetection) =  MONTH(GETDATE()) - 1

			union select 

				ViewArchive.Id,
				ViewArchive.CarsId,
				ViewArchive.CarBrand,
				ViewArchive.StateNumber,
				ViewArchive.Malfunction,
				ViewArchive.Worker,
				ViewArchive.IsFixed,
				ViewArchive.DateOfDetection,
				ViewArchive.DateOfCorrection
			from ViewArchive
			where MONTH(ViewArchive.DateOfDetection) =  MONTH(GETDATE()) - 1
go

------------------------------------------------------------------------------------------------------------------------------------------------------//


