using ClassLibrary1;
using EfCoreBasics.Models;
using EntityFrameworkStart.Database.Models;
using EntityFrameworkStart.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EfCoreBasics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;


        public HomeController(ILogger<HomeController> logger,ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //StudentRepo st = new StudentRepo(_context);
            //try
            //{
            //var item = st.GetStudent();

            //}
            //catch(Exception ex)
            //{
            //    string error = ex.Message;
            //}
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Add(Student model)
        {
            //StudentRepo sr = new StudentRepo();
            //sr.Add(model);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
