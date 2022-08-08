using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class Query4View
    {
        public string Name { private get; set; }//Имя
        public string Surename { private get; set; }//Фамилия
        public string Patronymic { private get; set; }//Отчество 

        public string FullName { get => Surename + " " + Name + " " + Patronymic; }

        public string Specialization { get; set; }//Специальность 

        public bool IsFixed { private get; set; }//Признак  исправленности поломки 

        public DateTime DateOfCorrection { private get; set; }//Дата исправления неисправность
        public string DateOfCorrectionLine { get => $"{DateOfCorrection:dd.MM.yyy}"; } //формат для вывода
    }
}
