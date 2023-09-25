using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiEg.Models;
using WebApiEg.Repository;

namespace WebApiEg.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]//open application without authorization

    public class StudentController : Controller
    {
        public readonly StudentRepository _studentRepo;
        public StudentController()
        {
            _studentRepo = new StudentRepository(); 
        }
        [HttpPost]
        public IActionResult Save(StudentData data)
        {
            string result = _studentRepo.Save(data);
            return Ok("Success");
        }

       [HttpGet]   
        public IActionResult Display([FromQuery]int id)
        {
            StudentData std=new StudentData();
            std = _studentRepo.GetById(id);
            return Ok(std);
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _studentRepo.DeleteById(id);
            return Ok("Deleted");
        }

        [HttpGet]
        public IActionResult DisplayAll()
        {
            List<StudentData> std = _studentRepo.GetAll();
            return Ok(std);
        }

    }
}
