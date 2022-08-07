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

        public string Worker { get; set; }//ФИО рабочего
        public string Specialization { get; set; }//специальность рабочего

        public string CarBrand { get; set; }//модель авто, которое ремонтируют 
        public string StateNumber { get; set; }//гос номер

        public DateTime DateOfDetection { private get; set; } //Дата выявления неисправность
        public DateTime DateOfCorrection { private  get; set; }//Дата исправления неисправность

        public string DateOfDetectionLine { get => $"{DateOfDetection:dd.MM.yyy}"; } //формат для вывода
        public string DateOfCorrectionLine { get => $"{DateOfCorrection:dd.MM.yyy}"; } //формат для вывода

        public string Client { get; set; }//ФИО клиента
        public string Passport { get; set; }//Паспорт клиента

        public bool IsFixed { private get; set; }//Признак  исправленности поломки 
        public string IsFixedLine { get => IsFixed == true ? "Да": "Нет"; }

        public int Price { get; set; }//Стоимость ремонта 
    }
}
