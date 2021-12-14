using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PhoneMax_1._1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneMax_1._1.Controllers
{
    public class HomeController : Controller
    {
        
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserDetails()
        {
            return View();
        }
        public IActionResult LoginSignupPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginSignupPage(Registration registration)
        {
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into Registration (Name, Email, Password) Values ('{registration.Name}', '{registration.Email}','{registration.Password}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            ViewBag.Result = "Success";
            return RedirectToAction("");
        }
            public IActionResult Android()
        {
            return View();
        }
        public IActionResult Galaxy_M52()
        {
            return View();
        }
        public IActionResult GalaxyZ()
        {
            return View();
        }
        public IActionResult GalaxyNote()
        {
            return View();
        }
        public IActionResult GalaxyS21()
        {
            return View();
        }
        public IActionResult Redmi10Prime()
        {
            return View();
        }
        public IActionResult Redmi9()
        {
            return View();
        }
        public IActionResult RedmiNote10S()
        {
            return View();
        }
        public IActionResult Redmi9Activ()
        {
            return View();
        }
        public IActionResult A74()
        {
            return View();
        }
        public IActionResult A31()
        {
            return View();
        }
        public IActionResult A16()
        {
            return View();
        }
        public IActionResult F19()
        {
            return View();
        }
        public IActionResult Iphone()
        {
            return View();
        }
        public IActionResult Iphone5()
        {
            return View();
        }
        public IActionResult Iphone6()
        {
            return View();
        }
        public IActionResult Iphone7()
        {
            return View();
        }
        public IActionResult Iphone8()
        {
            return View();
        }
        public IActionResult Iphone11Pro()
        {
            return View();
        }
        public IActionResult Iphone11ProMax()
        {
            return View();
        }
        public IActionResult Iphone12Pro()
        {
            return View();
        }
        public IActionResult Iphone13ProMax()
        {
            return View();
        }
        public IActionResult Windows()
        {
            return View();
        }
        public IActionResult Sucess()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
