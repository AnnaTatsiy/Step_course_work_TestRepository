using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using Step_course_work1_Anna_Tatsiy_.Context;
using Step_course_work1_Anna_Tatsiy_.Models;
using Step_course_work1_Anna_Tatsiy_.Views;
using System.Collections;

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
           //   Database.SetInitializer(new DropCreateDb());
          //  else
                Db = new CodeContext();

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
            Id=s.Id,
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
            StateNumber =c.StateNumber,
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
            Price = r.Malfunction.Price+r.SparePart.Price

        }).ToList();

        //--------------------------------------------------------------------------------------------------------

        //Запросы для ComboBox
        //Вывод всех гос номеров авто
        public IEnumerable GetStateNumbers() => Db.Cars.Select(c => new
        {
            c.Id,
            StateNumber = c.CarBrand.NameCarBrand + " ("+ c.StateNumber+")"
        }).ToList();

        //Вывод всех серий паспортов владельцев
        public IEnumerable GetPassports() => Db.Cars.Select(c => new
        {
            c.Id,
            Passport = c.Client.Person.Surename + " " + c.Client.Person.Name + " " + c.Client.Person.Patronymic +" |"+
            c.Client.Passport
        }).ToList();

        //Вывод всех неисправностей 
        public IEnumerable GetMalfunctions() => Db.Malfunctions.Select(m => new {
        
            m.Id,
            Malfunction = m.NameMalfunction
        
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
        public List<Malfunction> Query3(int id) => Db.Repairs.Where(r => r.Car.Client.Id == id && r.IsFixed == true).Select(r => r.Malfunction).ToList();

        //Запрос 4
        //Фамилия, имя, отчество работника станции, устранявшего данную неисправность в автомобиле данного клиента, и время ее устранения? 

        //Запрос 5
        //Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным типом неисправности? 
        public List<ClientView> Query5(int id) => Db.Repairs.Where(r=>r.Malfunction.Id == id).Select(c => new ClientView
        {
            Id = c.Client.Id,
            Surename = c.Client.Person.Surename,
            Name = c.Client.Person.Name,
            Patronymic = c.Client.Person.Patronymic,
            Passport = c.Client.Passport,
            Registration = c.Client.Registration,
            DateOfBirth = c.Client.DateOfBirth

        }).ToList();
    }
}
