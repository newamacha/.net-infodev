using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HallManagementSystem.Database.Model
{
    public class MeetingParticipantDetails
    {
        [Key]
        public int Participant_Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Role { get; set; }
        [Required]
        public DateTime JoinTime { get; set; }
        [Required]
        public DateTime LeaveTime { get; set; }
        public int MeetingId { get; set; }

        [ForeignKey("MeetingId")]
        public virtual Meeting Meeting { get; set; }
    }
}
