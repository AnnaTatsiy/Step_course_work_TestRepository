using System;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class Query4View
    {

        public string FullName { get; set; }

        public string Specialization { get; set; }//Специальность 

        public bool IsFixed { private get; set; }//Признак  исправленности поломки 
        public string IsFixedLine { get => IsFixed == true ? "Да" : "Нет"; }

        public DateTime DateOfCorrection { private get; set; }//Дата исправления неисправность
    }
}
