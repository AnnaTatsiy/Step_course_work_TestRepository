
using System.Collections.ObjectModel;
using Step_course_work1_Anna_Tatsiy_.Views;
using Step_course_work1_Anna_Tatsiy_.Command;
using System.Windows.Input;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    class CarVM : AppViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public new ICommand EditCarCommand { get; set; }
        private void EditCar(object obj) => CurrentView = new EditCarVM();

        //коллекция авто
        public ObservableCollection<CarView> Cars { get; private set; }

        public CarVM()
        {
            EditCarCommand = new RelayCommand(EditCar);
            Cars = new ObservableCollection<CarView>(_controller.GetCars());
        }
    }
}
