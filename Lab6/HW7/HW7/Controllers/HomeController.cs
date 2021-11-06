using System.Collections.Generic;
using System.Diagnostics;
using HW7.Data;
using HW7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PersonContext personContext = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            IEnumerable<Person> items = personContext.List;
            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Person p)
        {
            personContext.Add(p);
            return RedirectToAction("List");
        }


        public IActionResult Delete()
        {
            return Ok("ok");
        }


        public IActionResult SaveCustomer(Person person)
        {
            personContext.List.Add(person);
            return RedirectToAction("List");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}