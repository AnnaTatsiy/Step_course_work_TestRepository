using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Views;

using System.Collections.ObjectModel;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class Query1VM : AppViewModel
    {
        //выборка запроса 1
        private ObservableCollection<ClientView> _query1;
        public ObservableCollection<ClientView> Query1
        {
            get => _query1;
            private set
            {
                _query1 = value;
                OnPropertyChanged();
            }
        }

        //выборка запроса 1
        //Фамилия, имя, отчество и адрес владельца автомобиля с данным номером государственной регистрации? 
        private RelayCommand _selectByQuery1Command;

        public RelayCommand SelectByQuery1Command
        {
            get =>
            _selectByQuery1Command ??
            (_selectByQuery1Command = new RelayCommand(
            obj => {
                Query1 = new ObservableCollection<ClientView>(_controller.Query1(StateNumberId));
            }));
        }
    }
}
