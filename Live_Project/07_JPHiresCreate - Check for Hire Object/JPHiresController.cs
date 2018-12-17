Before:

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
	}     
		
After:

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
				JPCurrentJob currentJob = db.JPCurrentJobs.Where(x => x.ApplicationUserId == userID).FirstOrDefault();
				return RedirectToAction("Create", "JPCurrentJobs", currentJob);
			}
		}
		else
		{
			return View(jpHire);
		}
	}     