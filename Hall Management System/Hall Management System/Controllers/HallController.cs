using HallManagementSystem.Database.Model;
using HallManagementSystem.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Hall_Management_System.Controllers
{
    public class HallController : Controller
    {
        public IActionResult Index()
        {
            HallRepo st = new HallRepo();
            List<Hall> hallList=new List<Hall>();   
            try
            {
                 hallList = st.GetHall();
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
             return View(hallList);
        }
        //GET
        public IActionResult Add()
        {      
            return View();
        }

        //POST
        [HttpPost]
        public IActionResult Add(Hall model)
        {
            if (ModelState.IsValid)
            {
            HallRepo hr = new HallRepo();
            hr.Add(model);
            return RedirectToAction("Index");
            }
            return View(model);
        }

        //GET
        public IActionResult Edit(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            HallRepo st = new HallRepo();
            var model = st.GetById(id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //POST
        [HttpPost]
        public IActionResult Edit(Hall model)
        {
            if (ModelState.IsValid)
            {
                HallRepo hr = new HallRepo();
                hr.Update(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        //GET
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            HallRepo st = new HallRepo();
            var model = st.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //POST
        [HttpPost]
        public IActionResult Delete(Hall model)
        {
                HallRepo hr = new HallRepo();
                hr.Delete(model);
                return RedirectToAction("Index");    
        }
    }
}
