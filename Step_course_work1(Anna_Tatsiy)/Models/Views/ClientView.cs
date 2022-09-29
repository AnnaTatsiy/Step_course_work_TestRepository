using System;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    public class ClientView//класс для представления клиентов
    {
        public int Id { get; set; }//Id

        public string FullName { get; set; }//ФИО

        public string Passport { get; set; }//Паспорт
        public string Registration { get; set; }//Прописка

        public DateTime DateOfBirth {get; set; }//Дата рождения       
    }
}
