using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkStart.Database.Models
{
    public class DailyClass
    {
        public int ID { get; set; }
        public int TeacherId { get; set; }  
        public string Subject { get; set; } 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual Teacher Teacher { get; set; }    
        public virtual List<DailyClassDetail> Details { get; set; }
    }
}
