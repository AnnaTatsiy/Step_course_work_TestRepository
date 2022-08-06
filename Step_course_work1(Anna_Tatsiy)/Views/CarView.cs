using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class CarView//класс для представления авто
    {
        public int Id { get; set; }//Id

        public string CarBrand { get; set; }//Модель авто
        public string Color { get; set; }//Цвет авто

        public int YearOfRelease { get; set; }//год выпуска
        public string StateNumber { get; set; }//гос номер

        public string Owner { get; set; }//фио владельца
        public string OwnerPassport { get; set; }//серия паспорта владельца
    }
}
