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

        public int? IdCarBrand { get; set; }//Id модели
        public CarBrand CarBrand { get; set; }

        public int? IdColor { get; set; }//Id цвета
        public Color Color { get; set; }

        public int? IdClient { get; set; }//Id Владельца 
        public Client Client { get; set; }

    }
}
