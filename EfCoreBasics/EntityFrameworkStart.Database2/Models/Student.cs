using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkStart.Database.Models
{
    public class Student
    {
         //[Key]
        // [Required]
         //[DatabaseGenerated(DatabaseGeneratedOption.None)]
         public int Id { get; set; }
         [MaxLength(60)]
        public string FirstName { get; set; }   
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Faculty{ get; set; }
        public DateTime JoinDate{ get; set; }
        public string Address { get; set; }
    }
}
