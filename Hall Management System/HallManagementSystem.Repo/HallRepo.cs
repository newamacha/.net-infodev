using HallManagementSystem.Database;
using HallManagementSystem.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HallManagementSystem.Repo
{
    public class HallRepo
    {
        private readonly ApplicationContext _context;

        public HallRepo()
        {
            _context = new ApplicationContext();        
        }
        public HallRepo(ApplicationContext context)
        {
            _context = context;
        }

        public List<Hall> GetHall()
        {
            return _context.tbHall.ToList();
        }

        public void Add(Hall model)
        {
            _context.tbHall.Add(model);
            _context.SaveChanges();
        }

        public Hall GetById(int id)
        {
            //_context.tbHall.Where(x=>x.Id==id && x.Location == "Kalimati");
            //_context.tbHall.First(x=>x.Id==id);
            //_context.tbHall.FirstOrDefault(x=>x.Id==id);

            return _context.tbHall.Find(id);
        }

        public void Update(Hall model)
        {
            _context.tbHall.Update(model);
            _context.SaveChanges();
        }

        public void Delete(Hall model)
        {
            _context.tbHall.Remove(model);
            _context.SaveChanges();
        }
    }
}
