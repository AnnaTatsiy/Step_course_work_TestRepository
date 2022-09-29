using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Views;

using System.Collections.ObjectModel;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class Query5VM : AppViewModel
    {
        //выборка запроса 5
        private ObservableCollection<ClientView> _query5;
        public ObservableCollection<ClientView> Query5
        {
            get => _query5;
            private set
            {
                _query5 = value;
                OnPropertyChanged();
            }
        }

        //выборка запроса 5
        //Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным типом неисправности? 
        private RelayCommand _selectByQuery5Command;

        public RelayCommand SelectByQuery5Command
        {
            get =>
            _selectByQuery5Command ??
            (_selectByQuery5Command = new RelayCommand(
            obj => {
                Query5 = new ObservableCollection<ClientView>(_controller.Query5(MalfunctionId));
            }));
        }
    }
}
