#Passing a Model to a View

When a Congratulations screen was being created, it wasn't properly displaying the user's name.  The reason, it turns out, is because the model that was being passed didn't have entries for first name or last name.  It had an ApplicationUserID that was linked to the name via the database, which worked to access it in the controller C# file.  However, trying to call that connection in the Razor syntax which was tied strictly to the model being passed to it didn't work.  The easiest solution was just to add a couple of ViewBag messages containing the first name and last name in the Create (post) method and then call those in the resulting Details view.  But upon research this appears to be frowned upon as it's not as easy to follow.  ViewBag is kind of a "magic" property and you can't really use the data being passed that way for anything else in the future.

The solution was to create a View Model that contained all of the properties of JPHire (our model that lacked the names) in addition to the name.  But JPHire contains *nineteen* properties!  Oh, the tedious mapping!  Instead of jumping in to that I decided to poke around the internet.  It turns out you can simply create a property in the view which is the model you want to include!  Excellent.  Instead of creating nineteen identical properties in the View Model and mapping them nineteen times in the Controller, I could write one property and map *once*.  Phew!

The View Model then became:

###View Model

'''cs
public class JPHireWithNameViewModel
    {
        public JPHire Hire { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
'''

And here's the code for the Create method that was being modified followed by my addition:

###Original Code:

'''cs
[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JPHireId,JPStudentId,JPCompanyName,JPJobTitle,JPJobCategory,JPSalary,JPCompanyCity,JPCompanyState,JPSecondJob,JPCareersPage,JPHireDate")] JPHire jpHire)
        {
            if (ModelState.IsValid)
            {
                // Grabs the active users ID and uses it to identify the users row in JPStudents table to edit JPGraduated and JPHired from false to true.
                string userID = User.Identity.GetUserId();
                JPStudent jpStudent = db.JPStudents.Where(x => x.ApplicationUserId == userID).FirstOrDefault();
                jpStudent.JPGraduated = true;
                jpStudent.JPHired = true;
                
                
                //Auto-populating JPHireId, ApplicationUserId, and JPHireDate during user creation.
                jpHire.JPHireId = Guid.NewGuid();
                jpHire.JPHireDate = DateTime.Now;
                jpHire.ApplicationUserId = userID;
                
                db.Entry(jpStudent).State = EntityState.Modified;
                db.JPHires.Add(jpHire);
                

                //Create JPNotification record 

                JPNotification jpNotification = new JPNotification();
                jpNotification.JPStudent = jpStudent;
                jpNotification.Hire = true;
                jpNotification.NotificationDate = DateTime.Now;


                db.JPNotifications.Add(jpNotification);
                db.SaveChanges();

                return View("Details");
            }
		}
'''

###My Addition:

'''cs
		JPHireWithNameViewModel viewModel = new JPHireWithNameViewModel
		{
			Hire = jpHire,
			FirstName = jpStudent.ApplicationUser.FirstName,
			LastName = jpStudent.ApplicationUser.LastName
		};

		return View("Details", viewModel);
	}
	else
	{
		return View(jpHire);
	}
'''

I also changed all instances of jPHire to jpHire for readability and consistency with other variable or instance names, so the original isn't quite what it was really.  But this left one last bit of drudgery.  In the Details view, many of those nineteen properties were being called by model.PropertyName.  But since I was now using a view model, they all needed to be model.Hire.PropertyName.  After using search and replace to change a few specific properties, I realized that I could just change the middle bit on ALL of them at once.  Every name in the model starts with JP.  So I searched for "model.J" and replaced all instances with "model.Hire.J".  The cshtml code for that page is pretty long, so I won't include the full thing here.  The big change was how the name was called:

###Original Code:

'''cshtml
<h1 id="toWhite">
	Congratulations @Html.DisplayFor(model => model.ApplicationUser.FirstName) @Html.DisplayFor(model => model.ApplicationUser.LastName)
	<br />
	<br />
	on your recent hire at @Html.DisplayFor(model => model.JPCompanyName)!
</h1>
''''

###Updated Code:

'''cshtml
<h1 id="toWhite">
	Congratulations @Html.DisplayFor(model => model.FirstName) @Html.DisplayFor(model => model.LastName)
	<br />
	<br />
	on your recent hire at @Html.DisplayFor(model => model.Hire.JPCompanyName)!
</h1>
'''cshtml

There you have it, with all the pieces in place it worked beautifully.
