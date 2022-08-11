using System;
using System.Collections.Generic;
using System.Data.Entity;

using Step_course_work1_Anna_Tatsiy_.Models;

namespace Step_course_work1_Anna_Tatsiy_.Context
{
    internal class DropCreateDb : DropCreateDatabaseAlways<CodeContext>
    {
        protected override void Seed(CodeContext context)
        {
            base.Seed(context);

            Person p1 = new Person { Name = "Жанна", Surename = "Павлова", Patronymic = "Леонидовна" };
            Person p2 = new Person { Name = "Екатерина", Surename = "Баранова", Patronymic = "Климентьевна" };
            Person p3 = new Person { Name = "Даниил", Surename = "Алексеев", Patronymic = "Денисович" };
            Person p4 = new Person { Name = "Богдан", Surename = "Шевелев", Patronymic = "Русланович" };
            Person p5 = new Person { Name = "Аврора", Surename = "Фролова", Patronymic = "Матвеевна" };
            Person p6 = new Person { Name = "Диана", Surename = "Чернышева", Patronymic = "Александровна" };
            Person p7 = new Person { Name = "Анна", Surename = "Тарасова", Patronymic = "Степановна" };
            Person p8 = new Person { Name = "Алия", Surename = "Денисова", Patronymic = "Платоновна" };
            Person p9 = new Person { Name = "Леонид", Surename = "Александров", Patronymic = "Дмитриевич" };
            Person p10 = new Person { Name = "Арсений", Surename = "Верещагин", Patronymic = "Тимофеевич" };

            Person p11 = new Person { Name = "Анфиса", Surename = "Александрова", Patronymic = "Антоновна" };
            Person p12 = new Person { Name = "Сергей", Surename = "Семенов", Patronymic = "Павлович" };
            Person p13 = new Person { Name = "Глеб", Surename = "Малахов", Patronymic = "Леонидович" };
            Person p14 = new Person { Name = "Ирина", Surename = "Васильева", Patronymic = "Дмитриевна" };
            Person p15 = new Person { Name = "Артур", Surename = "Орлов", Patronymic = "Назарович" };
            Person p16 = new Person { Name = "Лев", Surename = "Емельянов", Patronymic = "Михайлович" };
            Person p17 = new Person { Name = "Тимофей", Surename = "Ефимов", Patronymic = "Маркович" };
            Person p18 = new Person { Name = "Иван", Surename = "Кузнецов", Patronymic = "Егорович" };
            Person p19 = new Person { Name = "Иван", Surename = "Иванов", Patronymic = "Даниэльевич" };
            Person p20 = new Person { Name = "Аиша", Surename = "Кондратьева", Patronymic = "Алексеевна" };
            context.Persons.AddRange(new List<Person> { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20 });

            Client c1 = new Client { Passport = "49302043", DateOfBirth = new DateTime(1987,4,2), Registration = "Серпухов, шоссе Гагарина, 17", Person = p1 };
            Client c2 = new Client { Passport = "34121043", DateOfBirth = new DateTime(1982, 10, 18), Registration = "Дорохово, пл. Будапештсткая, 63", Person = p2 };
            Client c3 = new Client { Passport = "51121221", DateOfBirth = new DateTime(1993, 11, 15), Registration = "Ступино, въезд Будапештсткая, 16", Person = p3 };
            Client c4 = new Client { Passport = "04875934", DateOfBirth = new DateTime(1975, 5, 8), Registration = "Серпухов, ул. Косиора, 45", Person = p4 };
            Client c5 = new Client { Passport = "58943533", DateOfBirth = new DateTime(1993, 9, 6), Registration = "Серпухов, пл. Ленина, 86", Person = p5 };
            Client c6 = new Client { Passport = "05032014", DateOfBirth = new DateTime(1971, 3, 23), Registration = "Шатура, ул. Гагарина, 60", Person = p6 };
            Client c7 = new Client { Passport = "94309204", DateOfBirth = new DateTime(1964, 4, 28), Registration = "Луховицы, пр. 1905 года, 96", Person = p7 };
            Client c8 = new Client { Passport = "03024576", DateOfBirth = new DateTime(1969, 2, 26), Registration = "Дорохово, пр. Космонавтов, 08", Person = p8 };
            Client c9 = new Client { Passport = "45054034", DateOfBirth = new DateTime(1983, 2, 12), Registration = "Воскресенск, проезд Чехова, 26", Person = p9 };
            Client c10 = new Client { Passport = "43095305", DateOfBirth = new DateTime(1980, 5, 20), Registration = "Можайск, ул. Будапештсткая, 07", Person = p10 };
            context.Clients.AddRange(new List<Client> {c1,c2,c3,c4,c5,c6,c7,c8,c9,c10 } );

            Specialization s1 = new Specialization { NameSpecialization = "Менеджер по запчастям" };
            Specialization s2 = new Specialization { NameSpecialization = "Автодиагност" };
            Specialization s3 = new Specialization { NameSpecialization = "Автожестянщик" };
            Specialization s4 = new Specialization { NameSpecialization = "Автомаляр" };
            Specialization s5 = new Specialization { NameSpecialization = "Автомеханик" };
            Specialization s6 = new Specialization { NameSpecialization = "Парковщик" };
            Specialization s7 = new Specialization { NameSpecialization = "Автослесарь" };
            Specialization s8 = new Specialization { NameSpecialization = "Автоэлектрик" };
            Specialization s9 = new Specialization { NameSpecialization = "Работник автомойки" };
            Specialization s10 = new Specialization { NameSpecialization = "Арматурщик" };
            Specialization s11 = new Specialization { NameSpecialization = "Жестянщик" };
            Specialization s12 = new Specialization { NameSpecialization = "Шиномонтажник" };
            context.Specializations.AddRange(new List<Specialization> {s1,s2,s3,s4,s5,s6,s7,s8,s9,s10,s11,s12});

            Worker w1 = new Worker { WorkersСategory = 1, Experience = 2 , Person = p11, Specialization = s1};
            Worker w2 = new Worker { WorkersСategory = 2, Experience = 3, Person = p12, Specialization = s2 };
            Worker w3 = new Worker { WorkersСategory = 3, Experience = 5, Person = p13, Specialization = s3 };
            Worker w4 = new Worker { WorkersСategory = 4, Experience = 6, Person = p14, Specialization = s4 };
            Worker w5 = new Worker { WorkersСategory = 1, Experience = 2, Person = p15, Specialization = s5 };
            Worker w6 = new Worker { WorkersСategory = 2, Experience = 2, Person = p16, Specialization = s6 };
            Worker w7 = new Worker { WorkersСategory = 3, Experience = 1, Person = p17, Specialization = s7 };
            Worker w8 = new Worker { WorkersСategory = 4, Experience = 4, Person = p18, Specialization = s8 };
            Worker w9 = new Worker { WorkersСategory = 1, Experience = 6, Person = p19, Specialization = s9 };
            Worker w10 = new Worker { WorkersСategory = 2, Experience = 10, Person = p20, Specialization = s10 };
            Worker w11 = new Worker { WorkersСategory = 2, Experience = 2, Person = p1, Specialization = s6 };
            Worker w12 = new Worker { WorkersСategory = 3, Experience = 1, Person = p2, Specialization = s7 };
            Worker w13 = new Worker { WorkersСategory = 4, Experience = 4, Person = p3, Specialization = s8 };
            Worker w14 = new Worker { WorkersСategory = 1, Experience = 6, Person = p4, Specialization = s9 };
            Worker w15 = new Worker { WorkersСategory = 2, Experience = 8, Person = p5, Specialization = s10 };
            context.Workers.AddRange(new List<Worker> { w1,w2,w3,w4,w5,w6,w7,w8,w9,w10,w11,w12,w13,w14,w15});

            CarBrand cb1 = new CarBrand { NameCarBrand = "УАЗ Pickup" };
            CarBrand cb2 = new CarBrand { NameCarBrand = "Skoda Karoq I" };
            CarBrand cb3 = new CarBrand { NameCarBrand = "Geely Atlas Pro" };
            CarBrand cb4 = new CarBrand { NameCarBrand = "Nissan Terrano III" };
            CarBrand cb5 = new CarBrand { NameCarBrand = "Toyota Camry VII" };
            CarBrand cb6 = new CarBrand { NameCarBrand = "LADA (ВАЗ) 2115" };
            CarBrand cb7 = new CarBrand { NameCarBrand = "Subaru Forester V" };
            CarBrand cb8 = new CarBrand { NameCarBrand = "Ford Focus II" };
            CarBrand cb9 = new CarBrand { NameCarBrand = "Volkswagen Touareg II" };
            CarBrand cb10 = new CarBrand { NameCarBrand = "Hyundai Accent ТагАЗ II" };
            CarBrand cb11 = new CarBrand { NameCarBrand = "Porsche Panamera 4S Executive" };
            CarBrand cb12 = new CarBrand { NameCarBrand = "Volkswagen Polo VI" };
            context.CarBrands.AddRange(new List<CarBrand>{ cb1,cb2,cb3,cb4,cb5,cb6,cb7,cb8,cb9,cb10,cb11,cb12 });

            Color cl1 = new Color { NameColor = "Серебристо-чёрный" };
            Color cl2 = new Color { NameColor = "Голубой" };
            Color cl3 = new Color { NameColor = "Тёмно-вишнёвый" };
            Color cl4 = new Color { NameColor = "Светло-серый" };
            Color cl5 = new Color { NameColor = "Белый" };
            Color cl6 = new Color { NameColor = "Зелёно-голубой" };
            Color cl7 = new Color { NameColor = "ярко-красный" };
            Color cl8 = new Color { NameColor = "Синий" };
            Color cl9 = new Color { NameColor = "Коричневый" };
            Color cl10 = new Color { NameColor = "Чёрный" };
            Color cl11 = new Color { NameColor = "Красный" };
            Color cl12 = new Color { NameColor = "Тёмно-синий" };
            context.Colors.AddRange(new List<Color> { cl1,cl2,cl3,cl4,cl5,cl6,cl7,cl8,cl9,cl10,cl11,cl12 });

            Car cr1 = new Car { YearOfRelease = 2020, StateNumber = "А695КА799",  CarBrand = cb1, Color = cl1, Client = c1 };
            Car cr2 = new Car { YearOfRelease = 2002, StateNumber = "Е123СС177",  CarBrand = cb2, Color = cl2, Client = c2 };
            Car cr3 = new Car { YearOfRelease = 2010, StateNumber = "Н681ТВ150",  CarBrand = cb3, Color = cl3, Client = c3 };
            Car cr4 = new Car { YearOfRelease = 2012, StateNumber = "К474СМ777",  CarBrand = cb4, Color = cl4, Client = c4 };
            Car cr5 = new Car { YearOfRelease = 2016, StateNumber = "Р259РР150",  CarBrand = cb5, Color = cl5, Client = c5 };
            Car cr6 = new Car { YearOfRelease = 2017, StateNumber = "Н700УУ37",  CarBrand = cb6, Color = cl6, Client = c6 };
            Car cr7 = new Car { YearOfRelease = 2021, StateNumber = "К858УН40",  CarBrand = cb7, Color = cl7, Client = c7 };
            Car cr8 = new Car { YearOfRelease = 2010, StateNumber = "У050КВ777",  CarBrand = cb8, Color = cl8, Client = c8 };
            Car cr9 = new Car {  YearOfRelease = 2022, StateNumber = "М700ММ96",  CarBrand = cb9, Color = cl9, Client = c9 };
            Car cr10 = new Car {  YearOfRelease = 2021, StateNumber = "К009МЕ68",  CarBrand = cb10, Color = cl10, Client = c10 };
            Car cr11 = new Car {  YearOfRelease = 2016, StateNumber = "А193СС190",  CarBrand = cb5, Color = cl5, Client = c5 };
            Car cr12= new Car {  YearOfRelease = 2017, StateNumber = "Н673УУ17",  CarBrand = cb6, Color = cl6, Client = c6 };
            Car cr13 = new Car {  YearOfRelease = 2021, StateNumber = "К581УН12",  CarBrand = cb7, Color = cl7, Client = c7 };
            Car cr14 = new Car {  YearOfRelease = 2010, StateNumber = "У080КВ719",  CarBrand = cb8, Color = cl8, Client = c8 };
            Car cr15 = new Car {  YearOfRelease = 2022, StateNumber = "М840ММ16",  CarBrand = cb9, Color = cl9, Client = c9 };
            Car cr16 = new Car {  YearOfRelease = 2021, StateNumber = "К899МЕ18",  CarBrand = cb10, Color = cl10, Client = c10 };
            context.Cars.AddRange(new List<Car> { cr1, cr2, cr3, cr4, cr5, cr6, cr7, cr8, cr9, cr10,cr11,cr12,cr13,cr14,cr15,cr16 });

            Malfunction m1 = new Malfunction { NameMalfunction = "Падение оборотов при ускорении." , Price = 2400};
            Malfunction m2 = new Malfunction { NameMalfunction = "Двигатель вращается, но не заводится.", Price = 4400 };
            Malfunction m3 = new Malfunction { NameMalfunction = "Вибрация колес.", Price = 2500 };
            Malfunction m4 = new Malfunction { NameMalfunction = "Шум и неровное вращение стартера.", Price = 1400 };
            Malfunction m5 = new Malfunction { NameMalfunction = "Двигатель в масле.", Price = 5800 };
            Malfunction m6 = new Malfunction { NameMalfunction = "Пропуски зажигания под нагрузкой.", Price = 2700 };
            Malfunction m7 = new Malfunction { NameMalfunction = "Двигатель останавливается.", Price = 5400 };
            Malfunction m8 = new Malfunction { NameMalfunction = "Большой расход топлива.", Price = 1400 };
            Malfunction m9 = new Malfunction { NameMalfunction = "Не включается передача.", Price = 3600 };
            Malfunction m10 = new Malfunction { NameMalfunction = "Шум в сцеплении.", Price = 2100 };
            Malfunction m11 = new Malfunction { NameMalfunction = "Повышенное усилие торможения.", Price = 8400 };
            Malfunction m12 = new Malfunction { NameMalfunction = "Повышенный износ шин.", Price = 1000 };
            context.Malfunctions.AddRange(new List<Malfunction> {m1,m2,m3,m4,m5,m6,m7,m8,m9,m10,m11,m12 });

            SparePart sp1 = new SparePart { NameSparePart = "Аккумулятор 100 ah", Price = 2000 };
            SparePart sp2 = new SparePart { NameSparePart = "Фильтр масляный", Price = 6400 };
            SparePart sp3 = new SparePart { NameSparePart = "Диодные птф G0237", Price = 2500 };
            SparePart sp4 = new SparePart { NameSparePart = "Фильтр салона VAG", Price = 500 };
            SparePart sp5 = new SparePart { NameSparePart = "Аккумулятор 60 ач", Price = 1000 };
            SparePart sp6 = new SparePart { NameSparePart = "Центровочное кольцо", Price = 400 };
            SparePart sp7 = new SparePart { NameSparePart = "Решетка в бампер", Price = 1700 };
            SparePart sp8 = new SparePart { NameSparePart = "Насос гур", Price = 3500 };
            SparePart sp9 = new SparePart { NameSparePart = "Фильтр топливный", Price = 2000 };
            SparePart sp10 = new SparePart { NameSparePart = "Расширители арок", Price = 4000 };
            SparePart sp11 = new SparePart { NameSparePart = "Накладка порога", Price = 500 };
            SparePart sp12 = new SparePart { NameSparePart = "Замок двери", Price = 2300 };
            context.SpareParts.AddRange(new List<SparePart>{ sp1, sp2, sp3, sp4, sp5, sp6, sp7,sp8,sp9,sp10,sp11,sp12 });

            Repair r1 = new Repair
            {
                DateOfDetection = new DateTime(2022,7,2),
                DateOfCorrection = new DateTime(2022,7,8),
                IsFixed = true,
                Malfunction = m1,
                Worker = w1,
                Car = cr1,
                Client = c1,
                SparePart = sp1
            };

            Repair r2 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,6),
                DateOfCorrection = new DateTime(2022, 7,10),
                IsFixed = true,
                Malfunction = m2,
                Worker = w2,
                Car = cr2,
                Client = c2,
                SparePart = sp2
            };
            Repair r3 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,6),
                DateOfCorrection = new DateTime(2022, 7,12),
                IsFixed = true,
                Malfunction = m3,
                Worker = w3,
                Car = cr3,
                Client = c3,
                SparePart = sp3
            };
            Repair r4 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,4),
                DateOfCorrection = new DateTime(2022, 7,10),
                IsFixed = true,
                Malfunction = m4,
                Worker = w4,
                Car = cr4,
                Client = c4,
                SparePart = sp4
            };
            Repair r5 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,9),
                DateOfCorrection = new DateTime(2022, 7,16),
                IsFixed = true,
                Malfunction = m5,
                Worker = w5,
                Car = cr5,
                Client = c5,
                SparePart = sp5
            };
            Repair r6 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,10),
                DateOfCorrection = new DateTime(2022, 7,15),
                IsFixed = true,
                Malfunction = m6,
                Worker = w6,
                Car = cr6,
                Client = c6,
                SparePart = sp6
            };
            Repair r7 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,15),
                DateOfCorrection = new DateTime(2022, 7,20),
                IsFixed = true,
                Malfunction = m7,
                Worker = w7,
                Car = cr7,
                Client = c7,
                SparePart = sp7
            };
            Repair r8 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,19),
                DateOfCorrection = new DateTime(2022, 7,22),
                IsFixed = true,
                Malfunction = m8,
                Worker = w8,
                Car = cr8,
                Client = c8,
                SparePart = sp8
            };
            Repair r9 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,20),
                DateOfCorrection = new DateTime(2022, 7,25),
                IsFixed = false,
                Malfunction = m9,
                Worker = w9,
                Car = cr9,
                Client = c9,
                SparePart = sp9
            };
            Repair r10 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,23),
                DateOfCorrection = new DateTime(2022, 7,27),
                IsFixed = true,
                Malfunction = m10,
                Worker = w10,
                Car = cr10,
                Client = c10,
                SparePart = sp10
            };
            Repair r11 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,24),
                DateOfCorrection = new DateTime(2022, 7,28),
                IsFixed = true,
                Malfunction = m9,
                Worker = w2,
                Car = cr2,
                Client = c6,
                SparePart = sp1
            };
            Repair r12 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,27),
                DateOfCorrection = new DateTime(2022, 7,30),
                IsFixed = true,
                Malfunction = m7,
                Worker = w2,
                Car = cr9,
                Client = c2,
                SparePart = sp5
            };
            Repair r13 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7,28),
                DateOfCorrection = new DateTime(2022, 7,31),
                IsFixed = true,
                Malfunction = m7,
                Worker = w8,
                Car = cr9,
                Client = c1,
                SparePart = sp2
            };
            Repair r14 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8,1),
                DateOfCorrection = new DateTime(2022, 8,5),
                IsFixed = true,
                Malfunction = m2,
                Worker = w1,
                Car = cr3,
                Client = c4,
                SparePart = sp5
            };
            Repair r15 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8,3),
                DateOfCorrection = new DateTime(2022, 8,8),
                IsFixed = true,
                Malfunction = m5,
                Worker = w6,
                Car = cr7,
                Client = c8,
                SparePart = sp9
            };

            Repair r16 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7, 24),
                DateOfCorrection = new DateTime(2022, 7, 28),
                IsFixed = true,
                Malfunction = m9,
                Worker = w2,
                Car = cr12,
                Client = c6,
                SparePart = sp1
            };
            Repair r17 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7, 27),
                DateOfCorrection = new DateTime(2022, 7, 30),
                IsFixed = true,
                Malfunction = m7,
                Worker = w2,
                Car = cr14,
                Client = c2,
                SparePart = sp5
            };
            Repair r18 = new Repair
            {
                DateOfDetection = new DateTime(2022, 7, 28),
                DateOfCorrection = new DateTime(2022, 7, 31),
                IsFixed = true,
                Malfunction = m7,
                Worker = w8,
                Car = cr15,
                Client = c1,
                SparePart = sp2
            };
            Repair r19 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 1),
                DateOfCorrection = new DateTime(2022, 8, 5),
                IsFixed = true,
                Malfunction = m2,
                Worker = w1,
                Car = cr13,
                Client = c4,
                SparePart = sp5
            };
            Repair r20 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 3),
                DateOfCorrection = new DateTime(2022, 8, 8),
                IsFixed = true,
                Malfunction = m5,
                Worker = w6,
                Car = cr11,
                Client = c8,
                SparePart = sp9
            };

            Repair r21 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 9),
                DateOfCorrection = new DateTime(2022, 8, 15),
                IsFixed = false,
                Malfunction = m3,
                Worker = w7,
                Car = cr8,
                Client = c1,
                SparePart = sp2
            };

            Repair r22 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 6),
                DateOfCorrection = new DateTime(2022, 8, 19),
                IsFixed = false,
                Malfunction = m2,
                Worker = w4,
                Car = cr8,
                Client = c2,
                SparePart = sp2
            };
            Repair r23 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 6),
                DateOfCorrection = new DateTime(2022, 8, 20),
                IsFixed = false,
                Malfunction = m3,
                Worker = w1,
                Car = cr9,
                Client = c8,
                SparePart = sp3
            };
            Repair r24 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 4),
                DateOfCorrection = new DateTime(2022, 8, 21),
                IsFixed = false,
                Malfunction = m4,
                Worker = w10,
                Car = cr10,
                Client = c6,
                SparePart = sp4
            };
            Repair r25 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 9),
                DateOfCorrection = new DateTime(2022, 8, 16),
                IsFixed = false,
                Malfunction = m5,
                Worker = w15,
                Car = cr15,
                Client = c5,
                SparePart = sp5
            };

            Repair r26 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 9),
                DateOfCorrection = new DateTime(2022, 8, 20),
                IsFixed = false,
                Malfunction = m1,
                Worker = w15,
                Car = cr12,
                Client = c5,
                SparePart = sp5
            };

            Repair r27 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 10),
                DateOfCorrection = new DateTime(2022, 8, 26),
                IsFixed = true,
                Malfunction = m5,
                Worker = w15,
                Car = cr15,
                Client = c5,
                SparePart = sp5
            };

            Repair r28 = new Repair
            {
                DateOfDetection = new DateTime(2022, 8, 10),
                DateOfCorrection = new DateTime(2022, 8, 29),
                IsFixed = true,
                Malfunction = m1,
                Worker = w15,
                Car = cr10,
                Client = c1,
                SparePart = sp5
            };

            context.Repairs.AddRange(new List<Repair> { r1,r2,r3,r4,r5,r6,r7,r8,r9,r10,r11,r12,r13,r14,r15,r16,r17,r18,r19,r20,r21,r22,r23,r24,r25,r26,r27,r28});

            context.SaveChanges();
        }
    }
}
