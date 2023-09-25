using HallManagementSystem.Database;
using HallManagementSystem.Database.Model;
using HallManagementSystem.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hall_Management_System.Controllers
{
    public class MeetingController : Controller
    {
        private readonly ApplicationContext db;
        public MeetingController(ApplicationContext db)
        {
            this.db = db;
        }
    
        public IActionResult Index()
        {
            MeetingRepo mt = new MeetingRepo();
            List<Meeting> meetingList = new List<Meeting>();
            try
            {
                meetingList = mt.GetMeeting();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return View(meetingList);

            //var model = db.tbMeeting.Include(d => d.Hall);
            //return View(model);
        }

        //GET
        public IActionResult Add()
        {
            IEnumerable<SelectListItem> TypeDropDown = db.tbHall.Select(i => new SelectListItem
            {
                Text= i.Name,
                Value=i.Id.ToString()
            });
            ViewBag.TypeDropDown = TypeDropDown;    
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Add(Meeting model)
        {
            if (ModelState.IsValid)
            {
                MeetingRepo mr = new MeetingRepo();
                mr.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}
