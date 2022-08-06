using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class RepairView//класс для представления ремонта авто
    {
        public int Id { get; set; }
        public string Malfunction { get; set; }//неисправность

        public int MyProperty { get; set; }
    }
}
