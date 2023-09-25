using HallManagementSystem.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace HallManagementSystem.Database
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }
        public ApplicationContext()
        {

        }
        public DbSet<Hall> tbHall{ get; set; }
        public DbSet<Meeting> tbMeeting { get; set; }
        public DbSet<MeetingParticipantDetails> tbMeetingParticipantDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=MANSIJ\\SQLEXPRESS;database=HallManagementSystem;uid=sa;password=123;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
