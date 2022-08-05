using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Models
{
    internal class Person// класс для сущности персоны 
    {
        public int Id { get; set; } //Id
        public string Name { get; set; }//Имя
        public string Surename { get; set; }//Фамилия
        public string Patronymic { get; set; }//Отчество 
    }
}
