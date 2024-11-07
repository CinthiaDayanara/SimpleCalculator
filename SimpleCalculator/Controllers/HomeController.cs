using Microsoft.AspNetCore.Mvc;
using System;

namespace SimpleCalculator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(double number1, double number2, string operation)
        {
            double result = 0;
            string error = null;

            try
            {
                switch (operation)
                {
                    case "Add":
                        result = number1 + number2;
                        break;
                    case "Subtract":
                        result = number1 - number2;
                        break;
                    case "Multiply":
                        result = number1 * number2;
                        break;
                    case "Divide":
                        if (number2 == 0)
                        {
                            error = "Cannot divide by zero.";
                        }
                        else
                        {
                            result = number1 / number2;
                        }
                        break;
                    default:
                        error = "Invalid operation.";
                        break;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            ViewData["Result"] = error ?? result.ToString();
            ViewData["Error"] = error;

            return View("Index");
        }
    }
}