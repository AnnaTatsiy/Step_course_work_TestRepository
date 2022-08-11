using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step_course_work1_Anna_Tatsiy_.Models
{
    internal class Repair//Ремонты
    {
        public int Id { get; set; }

        public Malfunction Malfunction { get; set; }//Id неисправность

        public Worker Worker { get; set; }//Id рабочего 

        public Car Car { get; set; }//Id авто 

        public DateTime DateOfDetection { get; set; } //Дата выявления неисправность
        public DateTime DateOfCorrection { get; set; }//Дата исправления неисправность

        public Client Client { get; set; }//Id клиента, который сдал авто на ремонт

        public bool IsFixed { get; set; }//Признак  исправленности поломки 

        public SparePart SparePart { get; set; }//Id запчасти для ремонта 
    }
}
