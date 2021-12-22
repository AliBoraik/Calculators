using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
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