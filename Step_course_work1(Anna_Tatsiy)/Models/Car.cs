using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Models
{
    internal class Car//авто
    {
        public int Id { get; set; }

        public int YearOfRelease { get; set; }//Год выпуска

        public string StateNumber { get; set; }//гос номер 

        public CarBrand CarBrand { get; set; }//Id модели

        public Color Color { get; set; }//Id цвета

        public Client Client { get; set; }//Id Владельца 

    }
}
