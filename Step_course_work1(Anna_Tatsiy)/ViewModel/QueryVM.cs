using Step_course_work1_Anna_Tatsiy_.Command;
using System.Windows.Input;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class QueryVM: AppViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand Query1Command { get; set; }
        public ICommand Query2Command { get; set; }
        public ICommand Query3Command { get; set; }
        public ICommand Query4Command { get; set; }
        public ICommand Query5Command { get; set; }
        public ICommand Query6Command { get; set; }

        private void Query1(object obj) => CurrentView = new Query1VM();
        private void Query2(object obj) => CurrentView = new Query2VM();
        private void Query3(object obj) => CurrentView = new Query3VM();
        private void Query4(object obj) => CurrentView = new Query4VM();
        private void Query5(object obj) => CurrentView = new Query5VM();
        private void Query6(object obj) => CurrentView = new Query6VM();

        public QueryVM() {

            Query1Command = new RelayCommand(Query1);
            Query2Command = new RelayCommand(Query2);
            Query3Command = new RelayCommand(Query3);
            Query4Command = new RelayCommand(Query4);
            Query5Command = new RelayCommand(Query5);
            Query6Command = new RelayCommand(Query6);

            // Startup Page
            CurrentView = new Query1VM();
        }
    }
}
