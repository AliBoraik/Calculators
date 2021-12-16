using HW11.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW11.Controllers
{
    public class DynamicController : Controller
    {
        public ActionResult Index(AdditionViewModel model, dynamic command)
        {
            if (command == "add") model.Result = model.A + model.B;
            if (command == "sub") model.Result = model.A - model.B;
            if (command == "mul") model.Result = model.A * model.B;
            if (command == "div") model.Result = model.A / model.B;
            return View(model);
        }
    }
}