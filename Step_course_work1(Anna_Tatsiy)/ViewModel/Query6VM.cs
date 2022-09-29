using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Views;
using System;

using System.Collections.ObjectModel;


namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class Query6VM : AppViewModel
    {
        //выборка запроса 6
        private ObservableCollection<Query6View> _query6;
        public ObservableCollection<Query6View> Query6
        {
            get => _query6;
            private set
            {
                _query6 = value;
                OnPropertyChanged();
            }
        }

        //выборка запроса 6
        //Самая распространенная неисправность в автомобилях указанной марки? 
        private RelayCommand _selectByQuery6Command;

        public RelayCommand SelectByQuery6Command
        {
            get =>
            _selectByQuery6Command ??
            (_selectByQuery6Command = new RelayCommand(
            obj => {
                Query6 = new ObservableCollection<Query6View>(_controller.Query6(CarBrandId));
            }));
        }
    }
}
