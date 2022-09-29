
using Step_course_work1_Anna_Tatsiy_.Views;
using Step_course_work1_Anna_Tatsiy_.Command;
using System.Windows;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class СhequeVM : AppViewModel
    {
        /*Оставляя автомобиль на станции техобслуживания, клиент получает расписку, в 
        * которой указано, когда автомобиль был поставлен на ремонт, какие он имеет 
        * неисправности, когда станция обязуется возвратить отремонтированный автомобиль.*/

        /*После возвращения автомобиля клиенту данные о произведенном ремонте помещаются в архив, 
        * клиент получает счет, в котором содержится перечень устраненных неисправностей с указанием    
        * времени работы, стоимости работы и стоимости запчастей.  */

        //Квитанция или чек
        private Сheque _receipt;

        public Сheque Receipt
        {
            get => _receipt;
            private set
            {
                _receipt = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _generateReceiptCommand;

        public RelayCommand GenerateReceiptCommand
        {
            get =>
            _generateReceiptCommand ??
            (_generateReceiptCommand = new RelayCommand(
            obj => {
                try
                {
                    Receipt = _controller.GetСheque(StateNumberId, PassportId, IsReceipt);
                }
                catch { MessageBox.Show("Заказ на ремонт не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); }
            }));
        }

        //формируем чек или квитанцию
        public bool IsReceipt { get; set; }

        public СhequeVM()
        {
            IsReceipt = true;
        }
    }
}
