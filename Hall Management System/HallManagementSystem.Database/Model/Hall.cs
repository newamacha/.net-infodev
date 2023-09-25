using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HallManagementSystem.Database.Model
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }

    }
}
