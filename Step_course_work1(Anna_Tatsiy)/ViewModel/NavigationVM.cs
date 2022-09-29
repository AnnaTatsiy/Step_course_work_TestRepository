
using Step_course_work1_Anna_Tatsiy_.Command;
using System.Windows.Input;


namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    class NavigationVM : AppViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand ClientsCommand { get; set; }
        public ICommand CarsCommand { get; set; }
        public ICommand WorkersCommand { get; set; }
        public ICommand RepairsCommand { get; set; }
        public ICommand ArchiveCommand { get; set; }
        public ICommand Query7Command { get; set; }
        public ICommand СhequeCommand { get; set; }
        public ICommand QueryCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand AboutCommand { get; set; }
        

        private void Client(object obj) => CurrentView = new ClientVM();
        private void Worker(object obj) => CurrentView = new WorkerVM();
        private void Car(object obj) => CurrentView = new CarVM();
        private void Repair(object obj) => CurrentView = new RepairVM();
        private void Archive(object obj) => CurrentView = new ArchiveVM();
        private void Query7(object obj) => CurrentView = new Query7VM();
        private void Query(object obj) => CurrentView = new QueryVM();
        private void Сheque(object obj) => CurrentView = new СhequeVM();
        private void Home(object obj) => CurrentView = new HomeVM();
        private void About(object obj) => CurrentView = new AboutVM();
       

        public NavigationVM()
        {
            ClientsCommand = new RelayCommand(Client);
            WorkersCommand = new RelayCommand(Worker);
            CarsCommand = new RelayCommand(Car);
            RepairsCommand = new RelayCommand(Repair);
            ArchiveCommand = new RelayCommand(Archive);
            Query7Command = new RelayCommand(Query7);
            QueryCommand = new RelayCommand(Query);
            СhequeCommand = new RelayCommand(Сheque);
            HomeCommand = new RelayCommand(Home);
            AboutCommand = new RelayCommand(About);
            
            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}
