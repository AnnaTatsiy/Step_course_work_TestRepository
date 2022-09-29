using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Views;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class AboutVM : AppViewModel
    {
        //время ремонта каждого автомобиля, список его неисправностей, сведения о работниках, осуществлявших ремонт.
        public ObservableCollection<CarView> LastReportCar { get; private set; }
        public List<CarView> LastReportCarList { get; private set; }

        public List<RepairView> LastReportList { get; private set; }

        //коллекция id авто
        public IEnumerable IdCars { get; private set; }

        private ObservableCollection<RepairView> _query14;
        public ObservableCollection<RepairView> Query14
        {
            get => _query14;
            private set
            {
                _query14 = value;
                OnPropertyChanged();
            }
        }

        //перечень отремонтированных за прошедший месяц и находящихся в ремонте автомобилей
        //время ремонта каждого автомобиля, список его неисправностей, сведения о работниках, осуществлявших ремонт.
        private RelayCommand _selectByQuery14Command;

        public RelayCommand SelectByQuery14Command
        {
            get =>
            _selectByQuery14Command ??
            (_selectByQuery14Command = new RelayCommand(
            obj => {
                Query14 = new ObservableCollection<RepairView>(_controller.Query14RepairView(LastReportList, CarId));
            }));
        }

        public AboutVM()
        {
            LastReportList = _controller.Query14();
            LastReportCarList = _controller.Query14CarView(LastReportList);
            LastReportCar = new ObservableCollection<CarView>(LastReportCarList);

            IdCars = _controller.GetIdCars(LastReportCarList);
        }
    }
}
