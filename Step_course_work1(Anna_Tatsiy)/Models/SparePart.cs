using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Models
{
    internal class SparePart//Доступные детали для ремонта авто
    {
        public int Id { get; set; }
        public string NameSparePart { get; set; }//Название детали для ремонта
        public int Price { get; set; }//Стоимость детали 
    }
}
