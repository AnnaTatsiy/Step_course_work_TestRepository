﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    /*клиент получает счет, в котором содержится перечень устраненных неисправностей с указанием времени работы, стоимости работы и стоимости запчастей.*/
    internal class Сheque
    {
        public DateTime DateDelivery { private get; set; }//Дата сдачи авто
        public DateTime DateIssue { private get; set; }//Дата выдачи авто
        public List<MalfunctionView> Malfunctions { private get; set; }//неисправности
        public List<SparePartsView> SpareParts { private get; set; }//детали для ремонта 
        public ClientView Client { private get; set; }//клиент который получает расписку
        public CarView Car { get; set; }//автомобиль

        private int _price => Malfunctions.Where(m=> m.IsFixed == true).Sum(m=>m.Price) + SpareParts.Where(m => m.IsFixed == true).Sum(m => m.Price);//стоимость ремонта

        public override string ToString()
        {
            string s = $"\tДата сдачи авто: {DateDelivery:dd.MM.yyy}\n\n" +
                       $"\t\tКлиент: {Client.FullName}, серия {Client.Passport}\n" +
                       $"\t\tАвто: {Car.CarBrand}, номер {Car.StateNumber}\n" +
                       $"\tСтоимость ремонта:\n";

            foreach (var item in Malfunctions)
                s += $"\t\t{item.NameMalfunction,40} {item.Price}  {item.IsFixedLine}\n";

            s += "\n\tСтоимость деталей:\n";

            foreach (var item in SpareParts)
                s += $"\t\t{item.NameSparePart,40}{item.Price}\n";

            s += $"\n\n\t\t\tОбщая стоимость: {_price}\n\n" +
               $"\tДата когда станция обязуется возвратить авто: {DateIssue:dd.MM.yyy}\n\n";

            return s;
        }
    }
}
