using CarInsuranceQuoteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuoteMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetQuote(string firstName, string lastName, string emailAddress,
                                        DateTime dateOfBirth, string carYear, string carMake,
                                        string carModel, string duiString, int tickets, string coverageLevel)
        {
            bool dui = false;
            if (duiString == "true")
            {
                dui = true;
            }
            var quote = new Quote()
            {
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                BirthDate = dateOfBirth,
                CarMake = carMake,
                CarModel = carModel,
                Dui = dui,
                Tickets = tickets,
                CoverageLevel = coverageLevel
            };
            bool intCheck = Int32.TryParse(carYear, out int carYearInt);
            if (intCheck) quote.CarYear = carYearInt;
            else quote.CarYear = 0;
            bool? inputValid = AllInputValid(quote);
            if (inputValid == false)
            {
                ViewBag.Message("Make sure all fields are filled out.  Please try again!");
                return View("~/Views/Shared/Error.cshtml");
            }
            else if (inputValid == null)
            {
                ViewBag.Message("The model year you entered was not in a valid format.  Please enter digits in the format yyyy.");
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                using (CarInsuranceQuotesEntities db = new CarInsuranceQuotesEntities())
                {
                    GenerateQuote(quote);
                    db.Quotes.Add(quote);
                    db.SaveChanges();
                }
                //string returnView = (@"Home/Quote/");  //Will this work?!
                ViewBag.quoteValue = quote.QuoteValue;
                ViewBag.firstName = quote.FirstName;
                return View("Quote");
             }
        }

        public bool? AllInputValid(Quote quote)
        {
            if (string.IsNullOrEmpty(quote.FirstName) || string.IsNullOrEmpty(quote.LastName) || string.IsNullOrEmpty(quote.EmailAddress) ||
                string.IsNullOrEmpty(quote.CarMake) || string.IsNullOrEmpty(quote.CarModel))
            {
                return false;
            }
            else if (quote.CarYear == 0) return null;
            else return true;
        }

        public Quote GenerateQuote(Quote quote)
        {
            decimal price = 25; // Base price per month

            // Checking for Age modifiers
            TimeSpan userAgeSpan = DateTime.Now - quote.BirthDate;
            double userAge = userAgeSpan.TotalDays / 365;
            if (userAge < 25 && userAge > 18) price += 25;
            if (userAge < 18) price += 100;
            if (userAge > 100) price += 25;

            // Checking for Car Year modifiers
            int carAge = quote.CarYear - 2000;
            if (carAge < 0) price += 25;
            if (carAge > 15) price += 25;

            // Checking for Make and Model modifiers
            if (quote.CarMake == "Porsche") price += 25;
            if (quote.CarModel == "911 Carrera") price += 25;

            // Speeding Ticket Modifier
            price += (decimal)quote.Tickets * 10;

            // DUI Modifier
            if (quote.Dui == true)
            {
                price *= 1.25m;
            }

            // Full Coverage Modifier
            if (quote.CoverageLevel == "Full Coverage")
            {
                price *= 1.50m;
            }

            quote.QuoteValue = price;
            return quote;
        }
    }
}