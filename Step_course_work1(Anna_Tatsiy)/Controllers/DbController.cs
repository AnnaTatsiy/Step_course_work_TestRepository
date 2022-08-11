using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using Step_course_work1_Anna_Tatsiy_.Context;
using Step_course_work1_Anna_Tatsiy_.Models;
using Step_course_work1_Anna_Tatsiy_.Views;
using System.Collections;
using System.Data.SqlClient;

namespace Step_course_work1_Anna_Tatsiy_.Controllers
{
    internal class DbController
    {
        public CodeContext Db { get; set; }

        public DbController()
        {
            //Условие не работает!!!
            // создание и ициализация базы данных
            // if (!Database.Exists("CourseWorkDb")) 
            //Database.SetInitializer(new DropCreateDb());
            //  else
            Db = new CodeContext();
            CreateArchive();
        }

        //Создание архива 
        private void CreateArchive()
        {
            string sql = "CreateArchiveSql";
            var createArchive = Db.Database.ExecuteSqlCommand(sql);

            createArchive.ToString();
        }

        //Архив 
        public List<RepairView> GetArchive()
        {

            string sql = " select * from ViewArchive";
            var getArchive = Db.Database.SqlQuery<RepairView>(sql);

            return getArchive.ToList();
        }


        //Таблица клиенты 
        public List<ClientView> GetClients() => Db.Clients.Select(c => new ClientView
        {
            Id = c.Id,
            Surename = c.Person.Surename,
            Name = c.Person.Name,
            Patronymic = c.Person.Patronymic,
            Passport = c.Passport,
            Registration = c.Registration,
            DateOfBirth = c.DateOfBirth

        }).ToList();

        //Таблица рабочие 
        public List<WorkerView> GetWorkers() => Db.Workers.Select(s => new WorkerView
        {
            Id = s.Id,
            Surename = s.Person.Surename,
            Patronymic = s.Person.Patronymic,
            Name = s.Person.Name,
            Specialization = s.Specialization.NameSpecialization,
            WorkerCategory = s.WorkersСategory,
            Experience = s.Experience

        }).ToList();

        //Таблица авто 
        public List<CarView> GetCars() => Db.Cars.Select(c => new CarView
        {
            Id = c.Id,
            CarBrand = c.CarBrand.NameCarBrand,
            Color = c.Color.NameColor,
            StateNumber = c.StateNumber,
            YearOfRelease = c.YearOfRelease,
            Owner = c.Client.Person.Surename + " " + c.Client.Person.Name + " " + c.Client.Person.Patronymic,
            OwnerPassport = c.Client.Passport

        }).ToList();

        //Таблица ремонты 
        public List<RepairView> GetRepairs() => Db.Repairs.Select(r => new RepairView {

            Id = r.Id,
            Malfunction = r.Malfunction.NameMalfunction,
            Worker = r.Worker.Person.Surename + " " + r.Worker.Person.Name + " " + r.Worker.Person.Patronymic,
            Specialization = r.Worker.Specialization.NameSpecialization,
            CarBrand = r.Car.CarBrand.NameCarBrand,
            StateNumber = r.Car.StateNumber,
            DateOfDetection = r.DateOfDetection,
            DateOfCorrection = r.DateOfCorrection,
            Client = r.Client.Person.Surename + " " + r.Client.Person.Name + " " + r.Client.Person.Patronymic,
            Passport = r.Client.Passport,
            IsFixed = r.IsFixed,
            Price = r.Malfunction.Price + r.SparePart.Price

        }).ToList();

        //--------------------------------------------------------------------------------------------------------

        //Запросы для ComboBox
        //Вывод всех гос номеров авто
        public IEnumerable GetStateNumbers() => Db.Cars.Select(c => new
        {
            c.Id,
            StateNumber = c.CarBrand.NameCarBrand + " (" + c.StateNumber + ")"

        }).ToList();

        //Вывод всех моделей авто
        public IEnumerable GetCarBrands() => Db.CarBrands.Select(c => new
        {
            c.Id,
            c.NameCarBrand

        }).ToList();

        //Вывод всех серий паспортов владельцев
        public IEnumerable GetPassports() => Db.Cars.Select(c => new
        {
            c.Client.Id,
            Passport = c.Client.Person.Surename + " " + c.Client.Person.Name + " " + c.Client.Person.Patronymic + " |" +
            c.Client.Passport

        }).Distinct().ToList();

        //Вывод всех клиентов 
        public IEnumerable GetClientsPassports() => Db.Clients.Select(c => new
        {
            c.Id,
            Passport = c.Person.Surename + " " + c.Person.Name + " " + c.Person.Patronymic + " |" +
            c.Passport
        }).ToList();

        //Вывод всех неисправностей 
        public IEnumerable GetMalfunctions() => Db.Malfunctions.Select(m => new {

            m.Id,
            Malfunction = m.NameMalfunction

        }).ToList();

        public IEnumerable GetSpecializations() => Db.Specializations.Select(s => new {
        
            s.Id,
            Specialization = s.NameSpecialization   

        }).ToList();

        //--------------------------------------------------------------------------------------------------------

        //Запрос 1
        //Фамилия, имя, отчество и адрес владельца автомобиля с данным номером государственной регистрации? 
        public List<ClientView> Query1(int id) => Db.Cars.Where(c=>c.Id == id).Select( c => new ClientView
        {
            Id = c.Id,
            Surename = c.Client.Person.Surename,
            Name = c.Client.Person.Name,
            Patronymic = c.Client.Person.Patronymic,
            Passport = c.Client.Passport,
            Registration = c.Client.Registration,
            DateOfBirth = c.Client.DateOfBirth

        }).ToList();

        //Запрос 2
        //Марка и год выпуска автомобиля данного владельца
        public List<CarView> Query2(int id) => Db.Cars.Where(c => c.Client.Id == id).Select(c => new CarView
        {
            Id = c.Id,
            CarBrand = c.CarBrand.NameCarBrand,
            Color = c.Color.NameColor,
            StateNumber = c.StateNumber,
            YearOfRelease = c.YearOfRelease,
            Owner = c.Client.Person.Surename + " " + c.Client.Person.Name + " " + c.Client.Person.Patronymic,
            OwnerPassport = c.Client.Passport

        }).ToList();

        //Запрос 3
        //Перечень устраненных неисправностей в автомобиле данного владельца? 
        public List<Malfunction> Query3(int id)
        {
            string sql = "Query3Sql @id";
            SqlParameter param = new SqlParameter("@id", id);

            var query = Db.Database.SqlQuery<Malfunction>(sql, param);

            return query.ToList();
        }

        //Запрос 4
        //Фамилия, имя, отчество работника станции, устранявшего данную неисправность в автомобиле данного клиента, и время ее устранения? 
        public List<Query4View> Query4(int malfunctionId, int clientId)
        {         
            string sql = "Query4Sql @clientId, @malfunctionId";
            SqlParameter param1 = new SqlParameter("@clientId", clientId);
            SqlParameter param2 = new SqlParameter("@malfunctionId", malfunctionId);

            var query = Db.Database.SqlQuery<Query4View>(sql, param1,param2);

            return query.ToList();
        }

        //Запрос 5
        //Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным типом неисправности? 
        public List<ClientView> Query5(int id)
        {
            string sql = "Query5Sql @id";
            SqlParameter param = new SqlParameter("@id",id);

            var query = Db.Database.SqlQuery<ClientView>(sql, param);

            return query.ToList();
        }

        //Запрос 6
        //Самая распространенная неисправность в автомобилях указанной марки?
        public List<Query6View> Query6(int carBrandId)
        {
            string sql = "select * from Query6Sql(@carBrandId)";
            SqlParameter param = new SqlParameter("@carBrandId", carBrandId);

            var query6 = Db.Database.SqlQuery<Query6View>(sql, param);

            return query6.ToList();
        }

        //Запрос 7
        //Количество рабочих каждой специальности на станции? 
        public List<Query7View> Query7()
        {
            string sql = "Query7Sql";
            var query7 = Db.Database.SqlQuery<Query7View>(sql);

            return query7.ToList();
        }

        //Запрос 8
        //Необходимо предусмотреть возможность выдачи справки о количестве автомобилей в ремонте на текущий момент
        public int Query8() => Db.Repairs.Where(r => r.IsFixed == false).Select(r=>r.Car.Id).Distinct().Count();

        //Запрос 9
        //количестве незанятых рабочих на текущий момент.  
        public int Query9() => Db.Workers.Count() - Db.Repairs.Where(r => r.IsFixed == false).Select(r => r.Worker.Id).Distinct().Count();

        //Запрос 10
        //Требуется также выдача месячного отчета о работе станции техобслуживания.В отчет должны войти данные о количестве устраненных неисправностей каждого вида и о доходе, полученном станцией
        public List<Query10View> Query10(int month)
        {
            string sql = "Query10Sql @month";
            SqlParameter param = new SqlParameter("@month", month);

            var query10 = Db.Database.SqlQuery<Query10View>(sql,param);

            return query10.ToList();
        }

        //Запрос 11
        //Найти прибыль за месяц 
        public int Query11(int month) => Query10(month).Sum(q => q.Profit);

        //Запрос 13 
        //Добавить работника
        public void AddWorker(string name, string surename , string patronymic, int specializationId, int workersСategory, int experience)
        {
            Db.Persons.Add(new Person { Name = name, Surename = surename, Patronymic = patronymic });

            Person person = Db.Persons.AsEnumerable().Last();
            int idPerson = person.Id;
            Specialization sp = Db.Specializations.Where(s => s.Id == specializationId).FirstOrDefault();

            Db.Workers.Add(new Worker { Person = person, Specialization = sp, Experience = experience, WorkersСategory = workersСategory});

            Db.SaveChanges();
        }

        //Запрос 14 
        //Удалить рабочего 
        public void DeleteWorker(int id)
        {
            string sql = "DropWorkerSql @id";
            SqlParameter param = new SqlParameter("@id", id);

            var query = Db.Database.ExecuteSqlCommand(sql, param);

            query.ToString();
        }
    }
}
