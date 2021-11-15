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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using EntityFramework.ViewModel;
using EntityFramework.Model;

namespace EntityFramework.View
{
    /// <summary>
    /// Логика взаимодействия для EditIncidentWindow.xaml
    /// </summary>
    public partial class EditIncidentWindow : MetroWindow
    {

        public static TextBox _TypeBlock;
        public static TextBox _NameBlock;
        public static TextBox _OpBlock;
        public static TextBox _RecBlock;
        public static TextBox _TimeBlock;
        public EditIncidentWindow(Incident incidentToEdit)
        {
            InitializeComponent();
            DataContext = new DataManageVM();
            DataManageVM.SelectIncident = incidentToEdit;
            DataManageVM.IncidentLvl = incidentToEdit.Lvl;
            DataManageVM.IncidentType = incidentToEdit.Type;
            DataManageVM.IncidentName = incidentToEdit.Name;
            DataManageVM.IncidentOp = incidentToEdit.Op;
            DataManageVM.IncidentRec = incidentToEdit.Rec;
            DataManageVM.IncidentStat = incidentToEdit.Stat;
            DataManageVM.IncidentTime = incidentToEdit.Time;

            _TypeBlock = TypeBlock;
            _NameBlock = NameBlock;
            _OpBlock = OpBlock;
            _RecBlock = RecBlock;
            _TimeBlock = TimeBlock;
        }
    }
}
