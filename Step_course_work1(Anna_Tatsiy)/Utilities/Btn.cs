using System.Windows;
using System.Windows.Controls;

namespace Step_course_work1_Anna_Tatsiy_.Utilities
{
    public class Btn: RadioButton
    {
        static Btn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Btn), new FrameworkPropertyMetadata(typeof(Btn)));
        }
    }
}
