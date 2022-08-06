using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class WorkerView//класс для представления рабочих
    {
        public int Id { get; set; }//Id

        public string Name { private get; set; }//Имя
        public string Surename { private get; set; }//Фамилия
        public string Patronymic { private get; set; }//Отчество 

        public string FullName { get => Surename + " " + Name + " " + Patronymic; }

        public string Specialization { get; set; }//Специальность 
        public int WorkerCategory { get; set; }//Разряд рабочего 
        public int Experience { get; set; }//Стаж
    }
}
