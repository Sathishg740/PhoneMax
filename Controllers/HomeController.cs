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
            if (check == 0)
            {

                return RedirectToAction("Index");
            }
            else
            {

                ViewBag.Query = 1;
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
            List<ProductDetails> UserList = new List<ProductDetails>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From ProductDetails where Product_Id = '7'";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ProductDetails user = new ProductDetails();
                        user.Product_Id = Convert.ToInt32(dataReader["Product_Id"]);
                        user.Product_Name = Convert.ToString(dataReader["Product_Name"]);
                        user.Category_Name = Convert.ToString(dataReader["Category_Name"]);
                        user.Brand_Name = Convert.ToString(dataReader["Brand_Name"]);
                        user.Price = Convert.ToInt32(dataReader["Price"]);
                        user.Description = Convert.ToString(dataReader["Description"]);
                        user.Image = Convert.ToString(dataReader["Image"]);
                        UserList.Add(user);
                        ViewBag.Id = Convert.ToInt32(dataReader["Product_Id"]);
                    }
                }
                connection.Close();

            }

            return View(UserList);
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
                string sql = "Select * From UserDetails ";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        UserDetails user = new UserDetails();
                      
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
            List<Product> products = new List<Product>() {
                new Product () {
                    Id = 1,
                    Photo = "https://m.media-amazon.com/images/I/71MmJNwZcML._SL1500_.jpg",
                    Name = "Galaxy Z Fold3 5G(Phantom Black, 12GB RAM, 256GB Storage)",
                    Price = 149999,
                    Offers="Bank Offer 100Rs",
                    Details=" Color: Black" +  "Available : InStock " + " Category : Android"
                },
            };
            ViewBag.products = products;
            return View();
        }

        public IActionResult ProductDisplay()
        {
            List<Product> products = new List<Product>() {
                new Product () {
                    Id = 1,
                    Photo = "https://m.media-amazon.com/images/I/71MmJNwZcML._SL1500_.jpg",
                    Name = "Galaxy Z Fold3 5G(Phantom Black, 12GB RAM, 256GB Storage)",
                    Price = 149999,
                    Offers="Bank Offer 100Rs",
                    Details=" Color: Black" +  "Available : InStock " + " Category : Android"
                },

            };
            ViewBag.products = products;
            return View();
        }

        public IActionResult CartPage()
        {
            List<ProductDetails> CartList = new List<ProductDetails>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From ProductDetails p, Cart c where c.Id = p.Product_Id";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ProductDetails user = new ProductDetails();
                        user.Product_Id = Convert.ToInt32(dataReader["Product_Id"]);
                        user.Product_Name = Convert.ToString(dataReader["Product_Name"]);
                        user.Category_Name = Convert.ToString(dataReader["Category_Name"]);
                        user.Brand_Name = Convert.ToString(dataReader["Brand_Name"]);
                        user.Price = Convert.ToInt32(dataReader["Price"]);
                        user.Description = Convert.ToString(dataReader["Description"]);
                        user.Image = Convert.ToString(dataReader["Image"]);
                        CartList.Add(user);
                        ViewBag.Id = Convert.ToInt32(dataReader["Product_Id"]);
                    }
                }
                connection.Close();

            }

            return View(CartList);

        }
        public IActionResult Cartinsert(int id)
        {
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into CartPage(Id) Values ('{id}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return View();
        }

        public IActionResult DisplayPage()
        {
            List<ProductDetails> UserList = new List<ProductDetails>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From ProductDetails where Product_Id = '7'";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ProductDetails user = new ProductDetails();
                        user.Product_Id = Convert.ToInt32(dataReader["Product_Id"]);
                        user.Product_Name = Convert.ToString(dataReader["Product_Name"]);
                        user.Category_Name = Convert.ToString(dataReader["Category_Name"]);
                        user.Brand_Name = Convert.ToString(dataReader["Brand_Name"]);
                        user.Price = Convert.ToInt32(dataReader["Price"]);
                        user.Description = Convert.ToString(dataReader["Description"]);
                        user.Image = Convert.ToString(dataReader["Image"]);
                        UserList.Add(user);
                        ViewBag.Id = Convert.ToInt32(dataReader["Product_Id"]);
                    }
                }
                connection.Close();

            }

            return View(UserList);
        }
    }
       
    }
