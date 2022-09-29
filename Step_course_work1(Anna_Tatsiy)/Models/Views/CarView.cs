
namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class CarView//класс для представления авто
    {
        public int Id { get; set; }//Id

        public int CarBrandsId { get; set; }//Id модели
        public string CarBrand { get; set; }//Модель авто

        public int ColorsId { get; set; }//Id цвета
        public string Color { get; set; }//Цвет авто

        public int YearOfRelease { get; set; }//год выпуска
        public string StateNumber { get; set; }//гос номер

        public int OwnerId { get; set; }//Id владельца 
        public string Owner { get; set; }//фио владельца
        public string OwnerPassport { get; set; }//серия паспорта владельца
    }
}
