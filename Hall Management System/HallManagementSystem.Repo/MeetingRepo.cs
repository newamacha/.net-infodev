using HallManagementSystem.Database;
using HallManagementSystem.Database.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HallManagementSystem.Repo
{
    public class MeetingRepo
    {
        private readonly ApplicationContext _context;

        public MeetingRepo()
        {
            _context = new ApplicationContext();
        }
        public MeetingRepo(ApplicationContext context)
        {
            _context = context;
        }

        public List<Meeting> GetMeeting()
        {
            return _context.tbMeeting.Include(d=> d.Hall).ToList();
        }

        public void Add(Meeting model)
        {
            _context.tbMeeting.Add(model);
            _context.SaveChanges();
        }

        public Meeting GetById(int id)
        {
            //_context.tbHall.Where(x=>x.Id==id && x.Location == "Kalimati");
            //_context.tbHall.First(x=>x.Id==id);
            //_context.tbHall.FirstOrDefault(x=>x.Id==id);

            return _context.tbMeeting.Find(id);
        }

        public void Update(Meeting model)
        {
            _context.tbMeeting.Update(model);
            _context.SaveChanges();
        }

        public void Delete(Meeting model)
        {
            _context.tbMeeting.Remove(model);
            _context.SaveChanges();
        }
    }

}
