using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Models
{
    internal class Client//клиент 
    {
        public int Id { get; set; }
        public string Passport { get; set; } //паспорт
        public string Registration { get; set; }//Прописка 
        public DateTime DateOfBirth { get; set; }//Дата рождения

        public Person Person { get; set; }//Id персоны 

    }
}
