using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HallManagementSystem.Database.Model
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string MeetingTopic { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int HallId { get; set; }

        [ForeignKey("HallId")]
        public virtual Hall Hall { get; set; }
        public virtual List<MeetingParticipantDetails> Details { get; set; }
    }
}
