using EntityFramework.Model;
using EntityFramework.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EntityFramework.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        public static string IncidentLvl { get; set; }
        public static string IncidentType { get; set; }
        public static string IncidentName { get; set; }
        public static string IncidentOp { get; set; }
        public static string IncidentRec { get; set; }
        public static string IncidentStat { get; set; }
        public static string IncidentTime { get; set; }
        public static Incident SelectIncident { get; set; }

        // Все инциденты
        private List<Incident> allIncident = DataWorker.GetIncidents();
        public List<Incident> AllIncident
        {
            get { return allIncident; }
            set
            {
                allIncident = value;
                NotifyPropertyChanged("AllIncident");
            }
        }


        // Добавить инцидент
        private RelayCommand addNewIncident;
        public RelayCommand AddNewIncident
        {
            get
            {
                return addNewIncident ?? new RelayCommand(obj =>
                {
                    UserControl wnd = obj as UserControl;
                    string resultStr = "";
                    if (IncidentName == null || IncidentName.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "NameBlock");
                    }
                    if (IncidentType == null || IncidentType.Replace(" ", "").Length == 0)
                    {
                        SetRedBlockControll(wnd, "TypeBlock");
                    }
                    else
                    {
                        resultStr = DataWorker.CreateIncident(IncidentLvl, IncidentType, IncidentName, IncidentOp, IncidentRec, IncidentStat, IncidentTime);
                        UpdateAllDataView();
                        SetNullValuesToPropperties();
                    }
                }
                );
            }
        }
        // Удалить инцидент
        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";

                    if (SelectIncident != null)
                    {
                        resultStr = DataWorker.DeleteIncident(SelectIncident);
                        UpdateAllDataView();
                    }

                    SetNullValuesToPropperties();
                });
            }
        }
        // Редактировать инцидент
        private RelayCommand editIncident;
        public RelayCommand EditIncident
        {
            get
            {
                return editIncident ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Не выбран инцидент";

                    if (SelectIncident != null)
                    {
                        resultStr = DataWorker.EditIncident(SelectIncident, IncidentLvl, IncidentType, IncidentName, IncidentOp, IncidentRec, IncidentStat, IncidentTime);
                        UpdateAllDataView();
                        SetNullValuesToPropperties();
                        //window.Close();                                             
                    }


                });
            }
        }
        // Редактировать объект
        private RelayCommand openEditItemWnd;
        public RelayCommand OpenEditItemWnd
        {
            get
            {
                return openEditItemWnd ?? new RelayCommand(obj =>
                {
                    if (SelectIncident != null)
                    {
                        OpenEditIncidentWindowMethod(SelectIncident);
                    }
                });
            }
        }

        private void OpenEditIncidentWindowMethod(Incident incident)
        {
            EditIncidentWindow editIncidentWindow = new EditIncidentWindow(incident);
            SetCenterPositionAndOpen(editIncidentWindow);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        private void SetRedBlockControll(UserControl wnd, string blockName)
        {
            Control block = wnd.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }
        private void SetNullValuesToPropperties()
        {
            IncidentLvl = null;
            IncidentType = null;
            IncidentName = null;
            IncidentOp = null;
            IncidentRec = null;
            IncidentStat = null;
            IncidentTime = null;

        }
        private void UpdateAllDataView()
        {
            UpdateAllIncidentView();
        }
        private void UpdateAllIncidentView()
        {
            AllIncident = DataWorker.GetIncidents();
            UserControlIncidents.AllIncidentView.ItemsSource = null;
            UserControlIncidents.AllIncidentView.Items.Clear();
            UserControlIncidents.AllIncidentView.ItemsSource = AllIncident;
            UserControlIncidents.AllIncidentView.Items.Refresh();

            UserControlNewIncident._TypeBlock.Text = null;
            UserControlNewIncident._NameBlock.Text = null;
            UserControlNewIncident._OpBlock.Text = null;
            UserControlNewIncident._RecBlock.Text = null;
            UserControlNewIncident._TimeBlock.Text = null;
                

            //EditIncidentWindow._TypeBlock.Text = null;
            //EditIncidentWindow._NameBlock.Text = null;
            //EditIncidentWindow._OpBlock.Text = null;
            //EditIncidentWindow._RecBlock.Text = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }

}
