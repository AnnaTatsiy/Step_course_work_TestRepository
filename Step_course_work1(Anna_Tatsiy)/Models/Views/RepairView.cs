using System;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class RepairView//класс для представления ремонта авто
    {
        public int Id { get; set; }

        public int MalfunctionId { get; set; }
        public string Malfunction { get; set; }//неисправность
        public int MalfunctionsPrice { get; set; }

        public int WorkersId { get; set; }
        public string Worker { get; set; }//ФИО рабочего
        public string Specialization { get; set; }//специальность рабочего

        public int CarsId { get; set; }
        public string CarBrand { get; set; }//модель авто, которое ремонтируют 
        public string StateNumber { get; set; }//гос номер

        public DateTime DateOfDetection {  get; set; } //Дата выявления неисправность
        public DateTime DateOfCorrection { get; set; }//Дата исправления неисправность
  
        public int ClientId { get; set; }
        public string Client { get; set; }//ФИО клиента
        public string Passport { get; set; }//Паспорт клиента

        public bool IsFixed { get; set; }//Признак  исправленности поломки 
        public string IsFixedLine { get => IsFixed == true ? "Да": "Нет"; }

        public int SparePartId { get; set; }//деталь для ремонта 
        public string SparePart { get; set; }
        public int SparePartPrice { get; set; }

        public int Price { get; set; }//Стоимость ремонта 
    }
}
