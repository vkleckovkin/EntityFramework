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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using EntityFramework.Model;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.ViewModel
{
    /// <summary>
    /// Логика взаимодействия для UserControlAnalis.xaml
    /// </summary>
    public partial class UserControlAnalis : UserControl
    {

        public UserControlAnalis()
        {
            InitializeComponent();
            DataContext = this;


            #region Значения уровня угрозы
            int lvlN = 0;
            int lvlS = 0;
            int lvlV = 0;
            int lvlK = 0;

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Lvl, "Низкий"));
                foreach (Incident incident in incidents)                  
                    lvlN = lvlN + 1;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Lvl, "Средний"));
                foreach (Incident incident in incidents)
                    lvlS += 1;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Lvl, "Высокий"));
                foreach (Incident incident in incidents)
                    lvlV = lvlV + 1;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Lvl, "Критический"));
                foreach (Incident incident in incidents)
                    lvlK = lvlK + 1;                
            }
            #endregion

            #region Значения статуса
            int statO = 0;
            int statZ = 0;

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Stat, "Закрыт"));
                foreach (Incident incident in incidents)                 
                    statZ = statZ + 1;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Stat, "В работе"));
                foreach (Incident incident in incidents)
                    statO = statO + 1;
            }
            #endregion

            #region Значения тип
            int typePp = 0;
            int typeNp = 0;
            int typeS = 0;
            int typeVp = 0;
            int typeEy = 0;

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Type, "%Перебор%"));
                foreach (Incident incident in incidents)
                    typePp = typePp + 1;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Type, "%Нарушение%"));
                foreach (Incident incident in incidents)
                    typeNp = typeNp + 1;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Type, "Спам"));
                foreach (Incident incident in incidents)
                    typeS = typeS + 1;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Type, "%Вредоносное ПО%"));
                foreach (Incident incident in incidents)
                    typeVp = typeVp + 1;
            }

            using (ApplicationContext db = new ApplicationContext())
            {
                var incidents = db.incidents.Where(p => EF.Functions.Like(p.Type, "%Эксплуатация%"));
                foreach (Incident incident in incidents)
                    typeEy = typeEy + 1;
            }
            #endregion


            //График уровень угрозы
            SeriesCollectionPie = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Низкий",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(lvlN)) },
                    DataLabels = true, 
                },
                new PieSeries
                {
                    Title = "Средний",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(lvlS)) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Высокий",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(lvlV)) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Критический",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(lvlK)) },
                    DataLabels = true
                }
            };

            //График статус
            SeriesCollectionPie1 = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Закрытые",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(statZ)) },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "В работе",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(statO)) },
                    DataLabels = true
                },
                
            };

            //Графикт тип инцидента
            SeriesCollectionPie2 = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Перебор паролей",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(typePp)) },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Нарушение политики ИБ",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(typeNp)) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Спам",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(typeS)) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "ВПО",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(typeVp)) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Эксплуатация уязвимостей",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(Convert.ToDouble(typeEy)) },
                    DataLabels = true
                },

            };

            SeriesCollection1 = new SeriesCollection
            {
                 new ColumnSeries
                 {
                     Title = "Инцидентов:",
                 Values = new ChartValues<double> {3,0,0,0,1,0,0,0,0,0,5,1,0,0,0,1,1,2,0,0,2,0,0,0,2,1,0,2,0,0,0,0 }
                 },
            };

            Labels = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", };
        }


        
        
         
        public SeriesCollection SeriesCollection1 { get; set; }
     
        public SeriesCollection SeriesCollectionPie { get; set; }
        public SeriesCollection SeriesCollectionPie1 { get; set; }
        public SeriesCollection SeriesCollectionPie2 { get; set; }
        public string[] Labels { get; set; }



    }
    
}
