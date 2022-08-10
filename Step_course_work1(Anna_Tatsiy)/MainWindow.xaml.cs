
using System.Windows;
using Step_course_work1_Anna_Tatsiy_.Windows;

namespace Step_course_work1_Anna_Tatsiy_
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewAddWindow_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
        }
    }
}
