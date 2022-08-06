using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Step_course_work1_Anna_Tatsiy_.Views;
using Step_course_work1_Anna_Tatsiy_.Controllers;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class AppViewModel : INotifyPropertyChanged
    {
        DbController _controller;

        //коллекция клиенты 
        public ObservableCollection<ClientView> Clients { get; private set; }
        //коллекция рабочие 
        public ObservableCollection<WorkerView> Workers { get; private set; }
        //коллекция авто
        public ObservableCollection<CarView> Cars { get; private set; }

        public AppViewModel()
        {
            _controller = new DbController();
            Clients = new ObservableCollection<ClientView>(_controller.GetClients());
            Workers = new ObservableCollection<WorkerView>(_controller.GetWorkers());
            Cars = new ObservableCollection<CarView>(_controller.GetCars());
        }

        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
