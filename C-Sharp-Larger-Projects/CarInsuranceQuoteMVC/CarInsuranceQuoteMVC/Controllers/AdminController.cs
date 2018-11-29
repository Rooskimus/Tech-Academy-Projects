using CarInsuranceQuoteMVC.Models;
using CarInsuranceQuoteMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuoteMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsuranceQuotesEntities db = new CarInsuranceQuotesEntities())
            {
                var quotes = db.Quotes.ToList();
                var quoteVms = new List<QuoteVm>();
                foreach (var quote in quotes)
                {
                    var quoteVm = new QuoteVm();
                    quoteVm.Id = quote.Id;
                    quoteVm.FirstName = quote.FirstName;
                    quoteVm.LastName = quote.LastName;
                    quoteVm.EmailAddress = quote.EmailAddress;
                    quoteVm.QuoteValue = quote.QuoteValue;
                    quoteVms.Add(quoteVm);
                }
                return View(quoteVms);
            }
        }
    }
}