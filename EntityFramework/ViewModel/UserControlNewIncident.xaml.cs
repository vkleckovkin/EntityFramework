using EntityFramework.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EntityFramework.Model;

namespace EntityFramework
{
    /// <summary>
    /// Логика взаимодействия для UserControlNewIncident.xaml
    /// </summary>
    public partial class UserControlNewIncident : UserControl
    {
        public static TextBox _TypeBlock;
        public static TextBox _NameBlock;
        public static TextBox _OpBlock;
        public static TextBox _RecBlock;
        
        public static TextBox _TimeBlock;

        public UserControlNewIncident()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            _TypeBlock = TypeBlock;
            _NameBlock = NameBlock;
            _OpBlock = OpBlock;
            _RecBlock = RecBlock;
            _TimeBlock = TimeBlock;
            
            
             
        }

        private void AddNewIncidentWnd_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
    }
}
