using EntityFrameworkStart.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClassLibrary1
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {

        }
        public ApplicationContext()
        {

        }
       // public DbSet<Student>tbStudent{get;set;}
        public DbSet<Teacher>tbTeacher{ get;set;} 
    }
}
