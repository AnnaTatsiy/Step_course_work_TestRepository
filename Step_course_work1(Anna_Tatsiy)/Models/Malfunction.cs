using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Models
{
    public class Malfunction//Доступные неисправности для авто
    {
        public int Id { get; set; }
        public string NameMalfunction { get; set; }//Название неисправности
        public int Price { get; set; }//Стоимость ремонта
    }
}
