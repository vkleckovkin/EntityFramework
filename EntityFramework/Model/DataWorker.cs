using System;
using System.Collections.Generic;
using System.Text;
using EntityFramework.Model;
using System.Linq;

namespace EntityFramework.Model
{
    public static class DataWorker
    {
        //Получить все инциденты
        public static List<Incident> GetIncidents()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.incidents.ToList();
                return result;
            }
        }
                                           
        // Создать инцидент
        public static string CreateIncident(string lvl, string type, string name, string op, string rec, string stat, string time)
        {
            string result = "Уже существует";

            using (ApplicationContext db = new ApplicationContext())
            {
                bool checkIsExist = db.incidents.Any(el => el.Name == name && el.Rec == rec);
                if (!checkIsExist)
                {
                    Incident newIncident = new Incident 
                    { Name = name,
                      Lvl = lvl,
                      Op = op,
                      Rec=rec, 
                      Type = type,
                      Stat = stat,
                      Time = time
                    };

                    db.incidents.Add(newIncident);
                    db.SaveChanges();
                    result = "Сделано!";
                }
                return result;
            }
        }

        // Удалить инцидент
        public static string DeleteIncident(Incident incident)
        {
            string result = "Инцидента не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.incidents.Remove(incident);
                db.SaveChanges();
                result = "Инцидент "+ incident.Name+ " удалён!";
            }
            return result;
        }

        // Редактировать инцидент
        public static string EditIncident(Incident oldIncident, string newlvl, string newType, string newName, string newOP, string newRec, string newStat, string newTime)
        {
            string result = "Инцидента не существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                Incident incident = db.incidents.FirstOrDefault(i => i.Id == oldIncident.Id);
                incident.Lvl = newlvl;
                incident.Name = newName;
                incident.Op = newOP;
                incident.Rec = newRec;
                incident.Type = newType;
                incident.Stat = newStat;
                incident.Time = newTime;
                db.SaveChanges();
                result = "Инцидент " + incident.Name + " изменён!";
            }
            return result;
        }

    }
}
