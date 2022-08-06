using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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
           //     Database.SetInitializer(new DropCreateDb());
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
    }
}
