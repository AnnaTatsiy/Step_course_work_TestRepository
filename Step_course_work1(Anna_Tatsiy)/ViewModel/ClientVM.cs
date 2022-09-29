
using System.Collections.ObjectModel;
using Step_course_work1_Anna_Tatsiy_.Views;

namespace Step_course_work1_Anna_Tatsiy_.ViewModel
{
    internal class ClientVM:AppViewModel
    {
        //коллекция клиенты 
        public ObservableCollection<ClientView> Clients { get; private set; }
        
        public ClientVM()
        {
            Clients = new ObservableCollection<ClientView>(_controller.GetClients());
        }
    }
}
