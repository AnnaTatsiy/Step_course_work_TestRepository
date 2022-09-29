
using System.Collections.ObjectModel;
using Step_course_work1_Anna_Tatsiy_.Views;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class Query7VM : AppViewModel
    {
        //Запрос 7
        public ObservableCollection<Query7View> Query7 { get; private set; }

        public Query7VM()
        {
            Query7 = new ObservableCollection<Query7View>(_controller.Query7());
        }
    }
}
