
using System.Collections.ObjectModel;
using Step_course_work1_Anna_Tatsiy_.Views;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class WorkerVM : AppViewModel
    {
        //коллекция рабочие 
        public ObservableCollection<WorkerView> Workers { get; private set; }

        public WorkerVM()
        {
            Workers = new ObservableCollection<WorkerView>(_controller.GetWorkers());
        }
    }
}
