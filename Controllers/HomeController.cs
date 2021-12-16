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
        [HttpPost]
        public IActionResult UserDetails(UserDetails user)
        {

            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into UserDetails (Name,Email,Address,City,State,Pincode) Values ('{user.Name}', '{user.Email}','{user.Address}', '{user.City}', '{user.State}','{user.Pncode}' )";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return RedirectToAction("Sucess");
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

            ViewBag.Result = 1;

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    DataTable dataTable = new DataTable();
            //    string sql1 = $"Select * From Register";
            //    SqlCommand command = new SqlCommand(sql1, connection);

            //    connection.Open();

            //    using (SqlDataReader dataReader = command.ExecuteReader())
            //    {
            //        while (dataReader.Read())
            //        {
            //            register.LoginEmail = Convert.ToString(dataReader["Email"]);
            //            register.LoginPassword = Convert.ToString(dataReader["Password"]);
            //        }
            //    }

            //    connection.Close();
            //}
            return View();

            // return RedirectToAction("");
        }
       
       
        
        public IActionResult Login(Registration register)
        {
           
            var check = 1;
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Select Email,Password From Registration where Email = '{register.LoginEmail}' and Password = '{register.LoginPassword}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                     var validate = command.ExecuteScalar();
                        if(validate!= null)
                    {
                        check = 0;

                    }
                    connection.Close();
                }
                
            }
            if (check==0)
            {
                return RedirectToAction("Index");
            }
          
            return RedirectToAction("LoginSignupPage");
          
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
            List<UserDetails> UserList = new List<UserDetails>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From UserDetails";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        UserDetails user = new UserDetails();
                        user.user_id = Convert.ToInt32(dataReader["user_id"]);
                        user.Name = Convert.ToString(dataReader["Name"]);
                        user.Email = Convert.ToString(dataReader["Email"]);
                        user.Address = Convert.ToString(dataReader["Address"]);
                        user.City = Convert.ToString(dataReader["City"]);
                        user.State = Convert.ToString(dataReader["State"]);
                        user.Pncode = Convert.ToInt32(dataReader["Pincode"]);
                        UserList.Add(user);
                    }
                }
                connection.Close();

            }
            return View(UserList);
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
