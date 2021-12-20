using Calculator_MVC.Middleware;
using Calculator_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculator_MVC.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [HttpGet]
        public IActionResult Result(Result result)
        {
            var resultObject = _calculator.Process(result.num1, result.opre, result.num2);

            return View("Result", resultObject);
        }
    }
}