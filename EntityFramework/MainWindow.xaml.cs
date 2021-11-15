using EntityFramework.View;
using EntityFramework.ViewModel;
using BeautySolutions.View.ViewModel;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;


namespace EntityFramework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
          
            //Инциденты
            var menuIncidents = new List<SubItem>();
            menuIncidents.Add(new SubItem("Список инцидентов", new UserControlIncidents()));
            menuIncidents.Add(new SubItem("Добавить инцидент", new UserControlNewIncident()));
            menuIncidents.Add(new SubItem("Анализ", new UserControlAnalis()));
            //menuIncidents.Add(new SubItem("Test", new UserControlTest()));

            var item6 = new ItemMenu("Инциденты", menuIncidents, PackIconKind.FormatListBulleted);  
       
            Menu.Children.Add(new UserControlMenuItem(item6, this));       
        }
        internal void SwitchScreen(object sender)
        {
            var screen = (UserControl)sender;

            if (screen != null)
            {
                StackpanelMain.Children.Clear();
                StackpanelMain.Children.Add(screen);
            }
        }

    }
}
