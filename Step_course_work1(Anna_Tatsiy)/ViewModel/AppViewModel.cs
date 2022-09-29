using System;

using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        
        protected DbController _controller;

        //Id Выбранного гос номер для запроса 1
        public int StateNumberId { get; set; }

        //Id выбранного клиента
        public int PassportId { get; set; }

        //Id Выбранной неисправности
        public int MalfunctionId { get; set; }

        //Id Выбранной модели авто
        public int CarBrandId { get; set; }

        //Выбранный месяц 
        public int Month { get; set; }

        //Id выбранного рабочего
        public int WorkerId { get; set; }

        //---------------------------------------------------------------------------------

        //добавление рабочего 
        public Worker AddWorker { get; set; }
        public Person Person { get; set; }
        public int SpecializationId { get; set; }

        //---------------------------------------------------------------------------------

        //Редактировать авто
        //public Car Car { get; set; }
        public int ColorId { get; set; }

        //---------------------------------------------------------------------------------

        // public int ClientiD { get; set; }
        public int ClientId { get; set; }

        public int CarId { get; set; }

        //Редактировать клиента
        private Client _selectedClient;

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                OnPropertyChanged();
            }
        } 

        //---------------------------------------------------------------------------------

        //коллекция гос номеров 
        public IEnumerable StateNumbers { get; private set; }
        //коллекция серий паспортов владельцев
        public IEnumerable Passports { get; private set; }
        //коллекция неисправностей
        public IEnumerable Malfunctions { get; private set; }
        //коллекция моделей авто 
        public IEnumerable CarBrands { get; private set; }
        //коллекция специальностей 
        public IEnumerable Specializations { get; private set; }
        //коллекция серий паспортов клиентов
        public IEnumerable ClientsPassports { get; private set; }
        //коллекция цветов авто
        public IEnumerable Colors { get; private set; }

        public Dictionary<string, int> Months { get; private set; } 

        public AppViewModel()
        {
            _controller = new DbController();

            StateNumbers = _controller.GetStateNumbers();
            Passports = _controller.GetPassports();
            Malfunctions = _controller.GetMalfunctions();
            CarBrands = _controller.GetCarBrands();
            Specializations = _controller.GetSpecializations();
            ClientsPassports = _controller.GetClientsPassports();
            Colors = _controller.GetColors();

            Months = new Dictionary<string, int>
            {
                ["Tекущий месяц"] = DateTime.Now.Month,
                ["Прошлый месяц"] = DateTime.Now.AddMonths(-1).Month
            };

            Person = new Person();
            AddWorker = new Worker();
            SelectedClient = new Client();

        }

        //Добавить рабочего 
        private RelayCommand _addWorkerCommand;

        public RelayCommand AddWorkerCommand
        {
            get =>
            _addWorkerCommand ??
            (_addWorkerCommand = new RelayCommand(
            obj => {
                _controller.AddWorker(Person.Name,Person.Surename,Person.Patronymic,SpecializationId,AddWorker.WorkersСategory,AddWorker.Experience);
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

        //изменение сведений о клиенте (клиент может поменять паспорт, адрес)
        private RelayCommand _editClientCommand;

        public RelayCommand EditClientCommand
        {
            get =>
            _editClientCommand ??
            (_editClientCommand = new RelayCommand(
            obj => {
                try
                {
                     SelectedClient.Id++;
                    _controller.EditClient(SelectedClient.Id, SelectedClient.Passport, SelectedClient.Registration);
                }
                catch { MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }));
        }

        //Редактировать авто
        public Car SelectedCar { get; set; }

        //номера государственной регистрации и цвета автомобиля. 
        private RelayCommand _editCarCommand;

        public RelayCommand EditCarCommand
        {
            get =>
            _editCarCommand ??
            (_editCarCommand = new RelayCommand(
            obj => {
                try
                {
                    _controller.EditCar(SelectedCar.Id, SelectedCar.StateNumber, SelectedCar.Color.Id);
                }
                catch { MessageBox.Show("Данные введены неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }));
        }

        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

    }
}
