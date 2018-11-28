using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using NewsletterAppMVC.Models;
using NewsletterAppMVC.ViewModels;

namespace NewsletterAppMVC.Controllers
{
    public class HomeController : Controller
    {
        // private readonly string _connectionString = ConfigurationManager.ConnectionStrings["newsletterDb"].ConnectionString;

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string firstName, string lastName, string emailAddress)
        {
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                // Manual Way:
                //string queryString = @"INSERT INTO SignUps (FirstName, LastName, EmailAddress) VALUES
                //                        (@FirstName, @LastName, @EmailAddress)";

                //using (SqlConnection connection = new SqlConnection(_connectionString))
                //{
                //    SqlCommand command = new SqlCommand(queryString, connection);
                //    command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                //    command.Parameters.Add("@LastName", SqlDbType.VarChar);
                //    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);

                //    command.Parameters["@FirstName"].Value = firstName;
                //    command.Parameters["@LastName"].Value = lastName;
                //    command.Parameters["@EmailAddress"].Value = emailAddress;

                //    connection.Open();
                //    command.ExecuteNonQuery();
                //    connection.Close();
                //}

                // Entity Framework Way

                using (NewsletterEntities db = new NewsletterEntities())
                {
                    var signup = new SignUp();
                    signup.FirstName = firstName;
                    signup.LastName = lastName;
                    signup.EmailAddress = emailAddress;

                    db.SignUps.Add(signup);
                    db.SaveChanges();
                }
                    return View("Success");
            }
        }

        //public ActionResult Admin()
        //{
            //Manual Way
            //string queryString = @"SELECT Id, FirstName, LastName, EmailAddress, SocialSecurityNumber from SignUps";
            //List<NewsletterSignUp> signups = new List<NewsletterSignUp>();

            //using (SqlConnection connection = new SqlConnection(_connectionString))
            //{
            //    SqlCommand command = new SqlCommand(queryString, connection);

            //    connection.Open();

            //    SqlDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        var signup = new NewsletterSignUp();
            //        signup.Id = Convert.ToInt32(reader["Id"]);
            //        signup.FirstName = reader["FirstName"].ToString();
            //        signup.LastName = reader["LastName"].ToString();
            //        signup.EmailAddress = reader["EmailAddress"].ToString();
            //        signup.SocialSecurityNumber = reader["SocialSecurityNumber"].ToString();
            //        signups.Add(signup);
            //    }
            //}
            //var signupVms = new List<SignupVm>();
			            //   foreach (var signup in signups)
			            //   {
				            //    var signupVm = new SignupVm();
				            //    signupVm.FirstName = signup.FirstName;
				            //    signupVm.LastName = signup.LastName;
				            //    signupVm.EmailAddress = signup.EmailAddress;
				            //    signupVms.Add(signupVm);
			            //   }
			 //   return View(signupVms);

            //Entity Framework Way

            //using (NewsletterEntities db = new NewsletterEntities())
            //{
            //    var signups = db.SignUps;
            //    var signupVms = new List<SignupVm>();
            //    foreach (var signup in signups)
            //    {
            //        var signupVm = new SignupVm();
            //        signupVm.FirstName = signup.FirstName;
            //        signupVm.LastName = signup.LastName;
            //        signupVm.EmailAddress = signup.EmailAddress;
            //        signupVms.Add(signupVm);
            //    }
            //    return View(signupVms);
            //}
            // The above code was moved to the AdminController class; I left this here for referential purposes for myself.


       // }
    }
}