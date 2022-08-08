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