using HW10.Data;
using HW10.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW10.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CalculatorController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(string mathProcess)
        {
            var item = _db.Items.Find(mathProcess);
            if (item == null) return NotFound();

            _db.Items.Remove(item);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Result(string mathProcess)
        {
            var item = _db.Items.Find(mathProcess);
            if (item == null)
            {
                var parser = new ExpressionParser();

                var result = parser.Execute(mathProcess);
                SetToDb(mathProcess, result);
                return View(result);
            }

            return View(item.Value);
        }

        private void SetToDb(string mathProcess, double result)
        {
            var newExpression = new Item {Operation = mathProcess, Value = result};
            _db.Items.Add(newExpression);
            _db.SaveChanges();
        }
    }
}