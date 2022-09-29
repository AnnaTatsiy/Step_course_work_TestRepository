
namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class SparePartsView
    {
        public int Id { get; set; }
        public string NameSparePart { get; set; }//Название детали для ремонта
        public int Price { get; set; }//Стоимость детали 

        public bool IsFixed { get; set; }//Признак  исправленности поломки 
    }
}
