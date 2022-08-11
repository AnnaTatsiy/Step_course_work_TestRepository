using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Models
{
    internal class Worker//рабочий 
    {
        public int Id { get; set; }

        public int WorkersСategory { get; set; }//Разряд рабочего
        public int Experience { get; set; }//Стаж

        public Person Person { get; set; }//Id персоны 

        public Specialization Specialization { get; set; }//Id специальности 
    }
}
