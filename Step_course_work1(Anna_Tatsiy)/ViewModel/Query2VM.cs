using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Views;

using System.Collections.ObjectModel;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class Query2VM: AppViewModel
    {
        //выборка запроса 2
        private ObservableCollection<CarView> _query2;
        public ObservableCollection<CarView> Query2
        {
            get => _query2;
            private set
            {
                _query2 = value;
                OnPropertyChanged();
            }
        }

        //выборка запроса 2
        //Марка и год выпуска автомобиля данного владельца
        private RelayCommand _selectByQuery2Command;

        public RelayCommand SelectByQuery2Command
        {
            get =>
            _selectByQuery2Command ??
            (_selectByQuery2Command = new RelayCommand(
            obj => {
                Query2 = new ObservableCollection<CarView>(_controller.Query2(PassportId));
            }));
        }

    }
}
