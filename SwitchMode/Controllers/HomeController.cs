using System;
using System.Linq;
using System.Web.Mvc;
using SwitchMode.Models;

namespace SwitchMode.Controllers
{
    public class HomeController : Controller
    {
        private static Model GetData()
        {
            return new Model
            {
                Days = new[]
                {
                    new Day
                    {
                        Date = new DateTime(2017, 10, 01),
                        Values = new[]
                        {
                            new Value {Description = "one", ActualValue = 1, Posted = true},
                            new Value {Description = "two", ActualValue = 2, Posted = false},
                            new Value {Description = "three", ActualValue = 3, Posted = true},
                        }
                    },
                    new Day
                    {
                        Date = new DateTime(2017, 10, 02),
                        Values = new[]
                        {
                            new Value {Description = "four", ActualValue = 4, Posted = false},
                            new Value {Description = "five", ActualValue = 5, Posted = false},
                            new Value {Description = "six", ActualValue = 6, Posted = true},
                        }
                    },
                    new Day
                    {
                        Date = new DateTime(2017, 10, 03),
                        Values = new[]
                        {
                            new Value {Description = "seven", ActualValue = 7, Posted = true},
                            new Value {Description = "eight", ActualValue = 8, Posted = true},
                            new Value {Description = "nine", ActualValue = 9, Posted = false},
                        }
                    }
                }
            };
        }

        public ActionResult Index()
        {
            var model = GetData();
            return View(model);
        }

        public PartialViewResult _OneDay(DateTime date)
        {
            var model = GetData().Days.Single(x => x.Date == date);
            return PartialView(model);
        }
    }
}