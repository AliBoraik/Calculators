using Calculator_ExpTrees.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator_ExpTrees.Controllers
{
    public class CalculatorController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(string mathProcess)
        {
            var parser = new ExpressionParser();

            var result = parser.Execute(mathProcess);
            return View(result);
        }
    }
}