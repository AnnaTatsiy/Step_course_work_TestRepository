using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Views;

using System.Collections.ObjectModel;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class Query4VM : AppViewModel
    {
        //выборка запроса 4
        private ObservableCollection<Query4View> _query4;
        public ObservableCollection<Query4View> Query4
        {
            get => _query4;
            private set
            {
                _query4 = value;
                OnPropertyChanged();
            }
        }

        //выборка запроса 4
        //Фамилия, имя, отчество работника станции, устранявшего данную неисправность в автомобиле данного клиента, и время ее устранения
        private RelayCommand _selectByQuery4Command;

        public RelayCommand SelectByQuery4Command
        {
            get =>
            _selectByQuery4Command ??
            (_selectByQuery4Command = new RelayCommand(
            obj => {
                Query4 = new ObservableCollection<Query4View>(_controller.Query4(MalfunctionId, PassportId));
            }));
        }
    }
}
