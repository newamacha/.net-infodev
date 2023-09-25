using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkStart.Database.Models
{
    public class DailyClassDetail
    {
        public int StudentId { get; set; }
        public DateTime JoinTime { get; set; }
        public DateTime LeaveTime { get; set; }
        public string Remarks { get; set; }
        public int DailyClassId { get; set; }

        public virtual Student Student { get; set; }    
        public virtual DailyClass DailyClass { get; set; }  

    }
}
