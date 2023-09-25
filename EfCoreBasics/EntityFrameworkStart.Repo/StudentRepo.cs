using ClassLibrary1;
using EntityFrameworkStart.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkStart.Repo
{
    public class StudentRepo
    {
        private readonly ApplicationContext _context;
        public StudentRepo()
        {

        }
        public StudentRepo(ApplicationContext context)
        {
            _context = context; 
          //  _context = new ApplicationContext();
        }
        ////Returns whole table data as list
        //public List<Student> GetStudent()
        //{
        //    return _context.tbStudent.ToList();
        //}

        ////Returns single row data as osm
        //public Student GetById(int id)
        //{
        //    return _context.tbStudent.Find(id);//search using primary key only
        //}

        ////Add Student data to database
        //public void Add(Student model)
        //{
        //    _context.tbStudent.Add(model);
        //    _context.SaveChanges();
        //}

        //Update Student data to databse    
       /* public void Update()
        {
            var model = GetById(1);

            var sec =new Student
            {
                
            }
        }
       */
    }
}
