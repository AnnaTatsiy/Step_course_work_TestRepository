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

--Запрос 12
--а также перечень отремонтированных за прошедший месяц и находящихся в ремонте автомобилей, время ремонта каждого автомобиля, список его неисправностей, сведения о работниках, осуществлявших ремонт. 
