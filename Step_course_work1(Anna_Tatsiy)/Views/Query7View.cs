using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class Query7View
    {
        //Количество рабочих каждой специальности на станции
        public int Id { get; set; }
        public string NameSpecialization { get; set; }//специальность рабочего
        public int CountWorkers { get; set; }//кол-во рабочих 
    }
}
