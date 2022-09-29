using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Models;

using System.Collections.ObjectModel;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class Query3VM : AppViewModel
    {
        //выборка запроса 3
        private ObservableCollection<Malfunction> _query3;
        public ObservableCollection<Malfunction> Query3
        {
            get => _query3;
            private set
            {
                _query3 = value;
                OnPropertyChanged();
            }
        }

        //выборка запроса 3
        //Перечень устраненных неисправностей в автомобиле данного владельца? 
        private RelayCommand _selectByQuery3Command;

        public RelayCommand SelectByQuery3Command
        {
            get =>
            _selectByQuery3Command ??
            (_selectByQuery3Command = new RelayCommand(
            obj => {
                Query3 = new ObservableCollection<Malfunction>(_controller.Query3(PassportId));
            }));
        }
    }
}
