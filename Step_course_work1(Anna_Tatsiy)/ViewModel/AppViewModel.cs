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
using System.Windows;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class AppViewModel : INotifyPropertyChanged
    {
        DbController _controller;

        //Id Выбранного гос номер для запроса 1
        public int StateNumberId { get; set; }

        //Id выбранного клиента
        public int PassportId { get; set; }

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

        //Id выбранного рабочего
        public int WorkerId { get; set; }

        //---------------------------------------------------------------------------------

        //добавление рабочего 
        public Worker AddWorker { get; set; }
        public Person Person { get; set; }

        //---------------------------------------------------------------------------------

        //коллекция клиенты 
        public ObservableCollection<ClientView> Clients { get; private set; }
        //коллекция рабочие 
        public ObservableCollection<WorkerView> Workers { get; private set; }
        //коллекция авто
        public ObservableCollection<CarView> Cars { get; private set; }
        //коллекция ремонтов 
        public ObservableCollection<RepairView> Repairs { get; private set; }

        //Архив 
        public ObservableCollection<RepairView> Archive { get; private set; }

        //коллекция гос номеров 
        public IEnumerable StateNumbers { get; private set; }
        //коллекция серий паспортов 
        public IEnumerable Passports { get; private set; }
        //коллекция неисправностей
        public IEnumerable Malfunctions { get; private set; }
        //коллекция моделей авто 
        public IEnumerable CarBrands { get; private set; }
        //коллекция специальностей 
        public IEnumerable Specializations { get; private set; }

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
            Archive = new ObservableCollection<RepairView>(_controller.GetArchive());

            StateNumbers = _controller.GetStateNumbers();
            Passports = _controller.GetPassports();
            Malfunctions = _controller.GetMalfunctions();
            CarBrands = _controller.GetCarBrands();
            Specializations = _controller.GetSpecializations();

            UnoccupiedWorkers = _controller.Query9();
            CarsRepair = _controller.Query8();

            Months = new Dictionary<string, int>
            {
                ["Tекущий месяц"] = DateTime.Now.Month,
                ["Прошлый месяц"] = DateTime.Now.AddMonths(-1).Month
            };

            AddWorker = new Worker();
            Person = new Person();
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
                Query1 = new ObservableCollection<ClientView>(_controller.Query1(StateNumberId));
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
                Query2 = new ObservableCollection<CarView>(_controller.Query2(PassportId));
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
                Query3 = new ObservableCollection<Malfunction>(_controller.Query3(PassportId));
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
                Query4 = new ObservableCollection<Query4View>(_controller.Query4(MalfunctionId,PassportId));
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

        //Добавить рабочего 
        private RelayCommand _addWorkerCommand;

        public RelayCommand AddWorkerCommand
        {
            get =>
            _addWorkerCommand ??
            (_addWorkerCommand = new RelayCommand(
            obj => {
                _controller.AddWorker(Person.Name,Person.Surename,Person.Patronymic,(int)AddWorker.IdSpecialization,AddWorker.WorkersСategory,AddWorker.Experience);
            }));
        }

        //Удалить рабочего 
        private RelayCommand _deleteWorkerCommand;

        public RelayCommand DeleteWorkerCommand
        {
            get =>
            _deleteWorkerCommand ??
            (_deleteWorkerCommand = new RelayCommand(
            obj => {
                try
                {
                    WorkerId++;
                    _controller.DeleteWorker(WorkerId);
                }
                catch { MessageBox.Show("Нельзя уволить работника, который ремонтирует авто", "Ошибка",MessageBoxButton.OK,MessageBoxImage.Error); }
            }));
        }


        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
