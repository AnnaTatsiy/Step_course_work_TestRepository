
using System.Collections.ObjectModel;
using Step_course_work1_Anna_Tatsiy_.Views;


namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class ArchiveVM : AppViewModel
    {
        //Архив 
        public ObservableCollection<RepairView> Archive { get; private set; }

        public ArchiveVM()
        {
            Archive = new ObservableCollection<RepairView>(_controller.GetArchive());
        }
    }
}
