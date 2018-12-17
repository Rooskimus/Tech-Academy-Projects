# Redirecting if Model Present for User

So this code was pretty straightforward, but testing it led me down a little rabbit hole.  Basically we wanted to make sure that every user only has one "JPHire" object in the database.  They decided to have the site redirect them to make a new "Current Job" object if one exists for a student.  I honestly don't understand the business logic here, as the JPCurrentJob  object is redundant and contains only properties that already exist in JPHire, and if you're logging the offer (Hire object) as accepting the offer, then that would be your Current Job, right?  But anyway, that's not in my realm of responsibility at the moment, although I did point that out when I submitted my change.  For the code at hand I simply instantiated a  JPHire object by pulling it from the database using the user's ID.  I placed the existing Create method into an If statement so it would create one if none existed.  If it didn't exist I redirected them to the Create method for JPCurrentJob instead in my else statement and passed along any existing Current Job model to the view.

### The Code:

```cs
[HttpPost]
 [ValidateAntiForgeryToken]
	public ActionResult Create([Bind(Include = "JPHireId,JPStudentId,JPCompanyName,JPJobTitle,JPJobCategory,JPSalary,JPCompanyCity,JPCompanyState,JPSecondJob,JPCareersPage,JPHireDate")] JPHire jpHire)
	{
		if (ModelState.IsValid)
		{
			// Grabs the active users ID and uses it to identify the users row in JPStudents table to edit JPGraduated and JPHired from false to true.
			string userID = User.Identity.GetUserId();
			JPHire existingHire = db.JPHires.Where(x => x.ApplicationUserId == userID).FirstOrDefault();
			if (existingHire == null)  // Check for existing JPHire for user; if not make one.  If so, redirect below.
			{
				(Code for Create method)
			}
			else
			{
				JPCurrentJob currentJob = db.JPCurrentJobs.Where(x => x.ApplicationUserId == userID).FirstOrDefault();
				return RedirectToAction("Create", "JPCurrentJobs", currentJob);
			}
		}
		else
		{
			return View(jpHire);
		}
	}     
```

Now testing it was tricky because I needed to find examples in the database that fit the criteria; one with a JPHire object and one without.  The ApplicationUserId was what linked it all, but finding which table that pointed to was a bit tricky because it was made in within a CS file in the models that had a different name and generated two tables in the database. It turns out that it was part of the scaffolded code for user authentication that VS creates if you select that option.  Eventually I was able to follow the dots and grab the right user login info to test my change above, and it worked as intended.
