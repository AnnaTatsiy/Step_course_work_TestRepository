using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Data.SqlClient;

using Step_course_work1_Anna_Tatsiy_.Context;
using Step_course_work1_Anna_Tatsiy_.Models;
using Step_course_work1_Anna_Tatsiy_.Views;

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
        private void CreateArchive() => Db.Database.ExecuteSqlCommand("CreateArchiveSql").ToString();
        //Архив 
        public List<RepairView> GetArchive() => Db.Database.SqlQuery<RepairView>("select * from ViewArchive").ToList();
        //Таблица клиенты 
        public List<ClientView> GetClients() => Db.Database.SqlQuery<ClientView>("select * from ViewClient").ToList();
        //Таблица рабочие 
        public List<WorkerView> GetWorkers() => Db.Database.SqlQuery<WorkerView>("select * from ViewWorkers").ToList();
        //Таблица авто 
        public List<CarView> GetCars() => Db.Database.SqlQuery<CarView>("select * from ViewCars").ToList();
        //Таблица ремонты 
        public List<RepairView> GetRepairs() => Db.Database.SqlQuery<RepairView>("select * from ViewRepairs").ToList();
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
            Passport = c.Client.Person.Surename + " " + c.Client.Person.Name + " " + c.Client.Person.Patronymic + " " +
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

        //Вывод всех цветов
        public IEnumerable GetColors() => Db.Colors.Select(m => new {

            m.Id,
            Color = m.NameColor

        }).ToList();

        //Вывод всех специальностей
        public IEnumerable GetSpecializations() => Db.Specializations.Select(s => new {
        
            s.Id,
            Specialization = s.NameSpecialization   

        }).ToList();

        //--------------------------------------------------------------------------------------------------------

        //Запрос 1
        //Фамилия, имя, отчество и адрес владельца автомобиля с данным номером государственной регистрации? 
        public List<ClientView> Query1(int id)
        {
            string sql = "Query1Sql @id";
            SqlParameter param = new SqlParameter("@id", id);

            var query = Db.Database.SqlQuery<ClientView>(sql, param);

            return query.ToList();
        }

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

            return query6.OrderByDescending(q=>q.CountMalfunctions).ToList();
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
        public List<Report> Query10(int month)
        {
            string sql = "Proc10Sql @month";
            SqlParameter param = new SqlParameter("@month", month);

            var query10 = Db.Database.SqlQuery<Report>(sql,param);

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

        /*Оставляя автомобиль на станции техобслуживания, клиент получает расписку, в 
        * которой указано, когда автомобиль был поставлен на ремонт, какие он имеет 
        * неисправности, когда станция обязуется возвратить отремонтированный автомобиль.*/
        public Сheque GenerateReceipt(int idCar, int idClient) => GetСheque( idCar, idClient, true);

        /*После возвращения автомобиля клиенту данные о произведенном ремонте помещаются в архив, 
         * клиент получает счет, в котором содержится перечень устраненных неисправностей с указанием 
         * времени работы, стоимости работы и стоимости запчастей.  */
        public Сheque GenerateСheque(int idCar, int idClient) => GetСheque(idCar, idClient, false);

        public Сheque GetСheque(int idCar, int idClient, bool isReceipt)
        {
            string sql;
            if (isReceipt) sql = "Query13Sql @idCar, @idClient";
            else sql = "Query12Sql @idCar, @idClient";

            SqlParameter param1 = new SqlParameter("@idCar", idCar);
            SqlParameter param2 = new SqlParameter("@idClient", idClient);

            List<RepairView> repairs = Db.Database.SqlQuery<RepairView>(sql, param1, param2).ToList();

            Сheque сheque = new Сheque()
            {

                DateDelivery = repairs.Min(r => r.DateOfDetection),
                DateIssue = repairs.Max(r => r.DateOfCorrection),

                Malfunctions = repairs.Select(r => new MalfunctionView
                {

                    Id = r.MalfunctionId,
                    NameMalfunction = r.Malfunction,
                    IsFixed = r.IsFixed,
                    Price = r.Price

                }).ToList(),

                SpareParts = repairs.Select(r => new SparePartsView
                {

                    Id = r.SparePartId,
                    NameSparePart = r.SparePart,
                    Price = r.SparePartPrice,
                    IsFixed = r.IsFixed

                }).ToList(),

                Client = repairs.Select(c => new ClientView
                {

                    Id = c.ClientId,
                    FullName = c.Client,
                    Passport = c.Passport

                }).FirstOrDefault(),

                Car = repairs.Select(c => new CarView
                {
                    Id = c.CarsId,
                    CarBrand = c.CarBrand,
                    StateNumber = c.StateNumber,

                }).FirstOrDefault(),

                isReceipt = isReceipt
            };

            return сheque;
        }

        //изменение сведений о клиенте (клиент может поменять паспорт, адрес)
        public void EditClient(int idClient, string passport, string registration)
        {
            string sql = " EditClientSql @idClient, @passport, @registration";
            SqlParameter param1 = new SqlParameter("@idClient", idClient);
            SqlParameter param2 = new SqlParameter("@passport", passport);
            SqlParameter param3 = new SqlParameter("@registration", registration);

            Db.Database.ExecuteSqlCommand(sql, param1, param2, param3).ToString();
        }

        //номера государственной регистрации и цвета автомобиля. 
        public void EditCar(int idCar, string stateNumber, int idColor)
        {
            string sql = " EditCarSql @idCar, @stateNumber, @idColor";
            SqlParameter param1 = new SqlParameter("@idCar", idCar);
            SqlParameter param2 = new SqlParameter("@stateNumber", stateNumber);
            SqlParameter param3 = new SqlParameter("@idColor", idColor);

            Db.Database.ExecuteSqlCommand(sql, param1, param2, param3).ToString();
        }

        //перечень отремонтированных за прошедший месяц и находящихся в ремонте автомобилей
        //время ремонта каждого автомобиля, список его неисправностей, сведения о работниках, осуществлявших ремонт.

        public List<RepairView> Query14() => Db.Database.SqlQuery<RepairView>("select * from Query14Sql()").ToList();

        //вывести только авто без повторений 
        public List<CarView> Query14CarView(List<RepairView> list) => list.Select(r => new CarView
        {
            Id = r.CarsId,
            CarBrand = r.CarBrand,
            StateNumber = r.StateNumber

        }).Distinct().ToList();

        //Запросы для ComboBox
        //Все id авто
        public IEnumerable GetIdCars(List<CarView> list) => list.Select(c => new
        {
            c.Id,
            
        }).ToList();

        //вывести данные о ремонте заданного авто 
        public List<RepairView> Query14RepairView(List<RepairView> list, int id) =>
            list.Where(r=>r.CarsId == id).Select(r => new RepairView
            {
                Malfunction = r.Malfunction,
                IsFixed = r.IsFixed,
                DateOfDetection = r.DateOfDetection,
                DateOfCorrection = r.DateOfCorrection,
                Worker = r.Worker

            }).ToList();
    }
}
