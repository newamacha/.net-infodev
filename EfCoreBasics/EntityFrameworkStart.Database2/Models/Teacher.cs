using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkStart.Database.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public long PhoneNo { get; set; }
        public DateTime JoinDate { get; set; }
        public string Address { get; set; }
    }
}
