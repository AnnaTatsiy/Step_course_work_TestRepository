
namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class MalfunctionView
    {
        public int Id { get; set; }
        public string NameMalfunction { get; set; }//Название неисправности
        public int Price { get; set; }//Стоимость ремонта

        public bool IsFixed { get; set; }//Признак  исправленности поломки 
        public string IsFixedLine { get => IsFixed == true ? "Да" : "Нет"; }
    }
}
