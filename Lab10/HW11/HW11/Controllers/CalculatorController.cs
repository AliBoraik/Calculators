using System;
using HW11.CustomException;
using HW11.Data;
using HW11.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW11.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalculatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(string mathProcess)
        {
            var item = _context.Items.Find(mathProcess);
            if (item == null) return NotFound();

            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        [CustomExceptionFilter]
        public IActionResult Result(string mathProcess)
        {
            var item = _context.Items.Find(mathProcess);
            if (item == null)
            {
                var parser = new ExpressionDynamic();
                Item result;
                try
                {
                    result = new Item
                    {
                        Value = parser.Execute(mathProcess),
                        Operation = mathProcess
                    };
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

                Context(result.Operation, result.Value);
                return View(result.Value);
            }
            
            return View(item.Value);
        }

        private void Context(string mathProcess, double result)
        {
            var newExpression = new Item {Operation = mathProcess, Value = result};
            _context.Items.Add(newExpression);
            _context.SaveChanges();
        }
    }
}