using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PublicTimetable.Models;

namespace PublicTimetable.Controllers
{
    [Route("airline")]
    public class AirlineController : Controller
    {
        private DataContext db = new DataContext();

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.airlineSchedule = db.AirlineSchedule.ToList();
            return View();
        }
    }
}