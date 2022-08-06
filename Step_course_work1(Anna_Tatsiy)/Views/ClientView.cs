using System;

namespace Step_course_work1_Anna_Tatsiy_.Views
{
    internal class ClientView//класс для представления клиентов
    {
        public int Id { get; set; }//Id

        public string Name { private get; set; }//Имя
        public string Surename { private get; set; }//Фамилия
        public string Patronymic { private get; set; }//Отчество 

        public string FullName { get => Surename + " " + Name + " " + Patronymic; }

        public string Passport { get; set; }//Паспорт
        public string Registration { get; set; }//Прописка

        public DateTime DateOfBirth {private get; set; }//Дата рождения
        public string DateOfBirthString { get => $"{DateOfBirth:dd.MM.yyy}"; } //формат для вывода
       
    }
}
