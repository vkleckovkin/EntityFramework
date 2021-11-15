using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Model
{
   public class Incident
    {
        public int Id { get; set; }
        public string Lvl { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Op { get; set; }
        public string Rec { get; set; }
        public string Stat { get; set; }
        public string Time { get; set; }


    }
}
