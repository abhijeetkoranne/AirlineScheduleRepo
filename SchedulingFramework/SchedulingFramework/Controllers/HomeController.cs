using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchedulingFramework.Models;
using Microsoft.Extensions.Configuration;
namespace SchedulingFramework.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;
        public HomeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Message()
        {
            return View();
        }
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/AirlinesData"

                        //,file.GetFilename()
                        , file.FileName
                        );

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            int counter = 0;
            string line;
            string FlightNumber, StartPeriodOfOperation, EndPeriodOfOperation;
            string DaysOfOperation, DepartureTime, OriginStation, DestinationStation, Aircraft;
            
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            SqlConnection con = new SqlConnection(connString);

                  // Read the file and display it line by line.  
                  System.IO.StreamReader fileRead =
                new System.IO.StreamReader(path);
            while ((line = fileRead.ReadLine()) != null)
            {
                //System.Console.WriteLine(line);

                FlightNumber = line.Substring(0, 6);
                StartPeriodOfOperation = line.Substring(6, 7);
                EndPeriodOfOperation = line.Substring(13, 7);
                DaysOfOperation = line.Substring(20, 7);
                DepartureTime = line.Substring(27, 4);
                OriginStation = line.Substring(31, 3);
                DestinationStation = line.Substring(34, 3);
                Aircraft = line.Substring(37, 3);
                counter++;
                
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertSchedule", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FlightNumber", FlightNumber);
                    cmd.Parameters.AddWithValue("@StartPeriodOfOperation", StartPeriodOfOperation);
                    cmd.Parameters.AddWithValue("@EndPeriodOfOperation", EndPeriodOfOperation);
                    cmd.Parameters.AddWithValue("@DaysOfOperation", DaysOfOperation);
                    cmd.Parameters.AddWithValue("@DepartureTime", DepartureTime);
                    cmd.Parameters.AddWithValue("@OriginStation", OriginStation);
                    cmd.Parameters.AddWithValue("@DestinationStation", DestinationStation);
                    cmd.Parameters.AddWithValue("@Aircraft", Aircraft);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                   
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                   
                }

            }

            fileRead.Close();
            return RedirectToAction("Message");
        }
    }
}
