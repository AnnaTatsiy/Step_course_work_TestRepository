
namespace Step_course_work1_Anna_Tatsiy_.Views
{
    //Требуется также выдача месячного отчета о работе станции техобслуживания.
    //В отчет должны войти данные о количестве устраненных неисправностей каждого вида и о доходе, полученном станцией
    internal class Report
    {
        public int Id { get; set; }
        public string NameMalfunction { get; set; }
        public int Count { get; set; }//кол-во неисправностей данного типа исправлено 
        public int Profit { get; set; }//прибыль 
    }
}
