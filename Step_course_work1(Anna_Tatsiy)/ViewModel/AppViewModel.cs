using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Step_course_work1_Anna_Tatsiy_.Views;
using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Controllers;
using Step_course_work1_Anna_Tatsiy_.Models;
using System.Collections;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class AppViewModel : INotifyPropertyChanged
    {
        DbController _controller;

        //Id Выбранного гос номер для запроса 1
        public int StateNumber { get; set; }

        //Id Серии паспорта для запроса 2
        public int Passport { get; set; }

        //Id Выбранной неисправности
        public int MalfunctionId { get; set; }

        //коллекция клиенты 
        public ObservableCollection<ClientView> Clients { get; private set; }
        //коллекция рабочие 
        public ObservableCollection<WorkerView> Workers { get; private set; }
        //коллекция авто
        public ObservableCollection<CarView> Cars { get; private set; }
        //коллекция ремонтов 
        public ObservableCollection<RepairView> Repairs { get; private set; }
        //коллекция гос номеров 
        public IEnumerable StateNumbers { get; private set; }
        //коллекция серий паспортов 
        public IEnumerable Passports { get; private set; }
        //коллекция неисправностей
        public IEnumerable Malfunctions { get; private set; }

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

        //выборка запроса 2
        private ObservableCollection<CarView> _query2;
        public ObservableCollection<CarView> Query2
        {
            get => _query2;
            private set
            {
                _query2 = value;
                OnPropertyChanged();
            }
        }

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

        public AppViewModel()
        {
            _controller = new DbController();
            Clients = new ObservableCollection<ClientView>(_controller.GetClients());
            Workers = new ObservableCollection<WorkerView>(_controller.GetWorkers());
            Cars = new ObservableCollection<CarView>(_controller.GetCars());
            Repairs = new ObservableCollection<RepairView>(_controller.GetRepairs());

            StateNumbers = _controller.GetStateNumbers();
            Passports = _controller.GetPassports();
            Malfunctions = _controller.GetMalfunctions();
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
                Query1 = new ObservableCollection<ClientView>(_controller.Query1(StateNumber));
            }));
        }

        //выборка запроса 2
        //Марка и год выпуска автомобиля данного владельца
        private RelayCommand _selectByQuery2Command;

        public RelayCommand SelectByQuery2Command
        {
            get =>
            _selectByQuery2Command ??
            (_selectByQuery2Command = new RelayCommand(
            obj => {
                Query2 = new ObservableCollection<CarView>(_controller.Query2(Passport));
            }));
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
                Query3 = new ObservableCollection<Malfunction>(_controller.Query3(Passport));
            }));
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

        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
