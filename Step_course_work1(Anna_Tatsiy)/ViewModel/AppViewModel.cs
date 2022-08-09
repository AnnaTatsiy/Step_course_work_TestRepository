using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Step_course_work1_Anna_Tatsiy_.Views;
using Step_course_work1_Anna_Tatsiy_.Command;
using Step_course_work1_Anna_Tatsiy_.Controllers;
using Step_course_work1_Anna_Tatsiy_.Models;
using System.Collections;
using System.Collections.Generic;

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

        //Id Выбранной модели авто
        public int CarBrandId { get; set; }

        //Кол-во свободных рабочих 
        public int UnoccupiedWorkers { get; set; }
        //Кол-во авто в ремонте 
        public int CarsRepair { get; set; }
        //Выбранный месяц 
        public int Month { get; set; }
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
        //коллекция моделей авто 
        public IEnumerable CarBrands { get; private set; }

        public Dictionary<string, int> Months { get; private set; } 

        //Запрос 7
        public ObservableCollection<Query7View> Query7 { get; private set; }

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

        //выборка запроса 4
        private ObservableCollection<Query4View> _query4;
        public ObservableCollection<Query4View> Query4
        {
            get => _query4;
            private set
            {
                _query4 = value;
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

        //выборка запроса 10
        private ObservableCollection<Query10View> _query10;
        public ObservableCollection<Query10View> Query10
        {
            get => _query10;
            private set
            {
                _query10 = value;
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
            Query7 = new ObservableCollection<Query7View>(_controller.Query7());

            StateNumbers = _controller.GetStateNumbers();
            Passports = _controller.GetPassports();
            Malfunctions = _controller.GetMalfunctions();
            CarBrands = _controller.GetCarBrands();

            UnoccupiedWorkers = _controller.Query9();
            CarsRepair = _controller.Query8();

            Months = new Dictionary<string, int>
            {
                ["Tекущий месяц"] = DateTime.Now.Month,
                ["Прошлый месяц"] = DateTime.Now.AddMonths(-1).Month
            };
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

        //выборка запроса 4
        //Фамилия, имя, отчество работника станции, устранявшего данную неисправность в автомобиле данного клиента, и время ее устранения
        private RelayCommand _selectByQuery4Command;

        public RelayCommand SelectByQuery4Command
        {
            get =>
            _selectByQuery4Command ??
            (_selectByQuery4Command = new RelayCommand(
            obj => {
                Query4 = new ObservableCollection<Query4View>(_controller.Query4(MalfunctionId,Passport));
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
               Query10 = new ObservableCollection<Query10View>(_controller.Query10(Month));           
            }));
        }


        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
