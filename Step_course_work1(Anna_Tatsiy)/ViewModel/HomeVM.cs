using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Views;

using System.Collections.ObjectModel;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class HomeVM: AppViewModel
    {
        //Кол-во свободных рабочих 
        public int UnoccupiedWorkers { get; set; }

        //Кол-во авто в ремонте 
        public int CarsRepair { get; set; }

        //выборка запроса 10
        private ObservableCollection<Report> _query10;
        public ObservableCollection<Report> Query10
        {
            get => _query10;
            private set
            {
                _query10 = value;
                OnPropertyChanged();
            }
        }

        //Доход станции
        private int _profit;

        public int Profit
        {
            get => _profit;
            private set
            {
                _profit = value;
                OnPropertyChanged();
            }
        }

        //выборка запроса 10
        //Требуется также выдача месячного отчета о работе станции техобслуживания. В отчет должны войти данные о количестве устраненных неисправностей каждого вида и о доходе, полученном станцией
        private RelayCommand _selectByQuery10Command;

        public RelayCommand SelectByQuery10Command
        {
            get =>
            _selectByQuery10Command ??
            (_selectByQuery10Command = new RelayCommand(
            obj => {
                Profit = _controller.Query11(Month);
                Query10 = new ObservableCollection<Report>(_controller.Query10(Month));
            }));
        }

        public HomeVM()
        {
            UnoccupiedWorkers = _controller.Query9();
            CarsRepair = _controller.Query8();
        }
    }
}
