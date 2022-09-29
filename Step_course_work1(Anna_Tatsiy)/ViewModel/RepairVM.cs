
using System.Collections.ObjectModel;
using Step_course_work1_Anna_Tatsiy_.Views;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class RepairVM : AppViewModel
    {
        //коллекция ремонтов 
        public ObservableCollection<RepairView> Repairs { get; private set; }

        public RepairVM()
        {
            Repairs = new ObservableCollection<RepairView>(_controller.GetRepairs());
        }
    }
}
