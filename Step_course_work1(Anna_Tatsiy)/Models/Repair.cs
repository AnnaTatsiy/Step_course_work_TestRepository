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

        public int? IdMalfunction { get; set; }//Id неисправность
        public Malfunction Malfunction { get; set; }

        public int? IdWorker { get; set; }//Id рабочего 
        public Worker Worker { get; set; }

        public int? IdCar { get; set; }//Id авто 
        public Car Car { get; set; }

        public DateTime DateOfDetection { get; set; } //Дата выявления неисправность
        public DateTime DateOfCorrection { get; set; }//Дата исправления неисправность

        public int? IdClient { get; set; }//Id клиента, который сдал авто на ремонт
        public Client Client { get; set; }

        public bool IsFixed { get; set; }//Признак  исправленности поломки 

        public int? IdSparePart { get; set; }//Id запчасти для ремонта 
        public SparePart SparePart { get; set; }
    }
}
