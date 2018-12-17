public ActionResult EmailYearlyStudents() 
	{
		var beginDate = DateTime.Now.AddYears(-1);
		var yearlyHires = from student in db.JPStudents
							join hire in db.JPHires
							on student.ApplicationUserId
							equals hire.ApplicationUserId
							where (hire.JPHireDate >= beginDate && hire.JPHireDate <= DateTime.Now)
							select student.JPEmail;
		string[] emailList = yearlyHires.ToArray();
		EmailStudentsBcc(emailList);
		return RedirectToAction("Snapshot");
	}

public ActionResult EmailMonthlyStudents()
	{
		var beginDate = DateTime.Now.AddMonths(-1);
		var monthlyHires = from student in db.JPStudents
						  join hire in db.JPHires
						  on student.ApplicationUserId
						  equals hire.ApplicationUserId
						  where (hire.JPHireDate >= beginDate && hire.JPHireDate <= DateTime.Now)
						  select student.JPEmail;
		string[] emailList = monthlyHires.ToArray();
		EmailStudentsBcc(emailList);
		return RedirectToAction("Snapshot");
	}

public ActionResult EmailWeeklyStudents()
	{
		var beginDate = DateTime.Now.AddDays(-7);
		var weeklyHires = from student in db.JPStudents
						  join hire in db.JPHires
						  on student.ApplicationUserId
						  equals hire.ApplicationUserId
						  where (hire.JPHireDate >= beginDate && hire.JPHireDate <= DateTime.Now)
						  select student.JPEmail;
		string[] emailList = weeklyHires.ToArray();
		EmailStudentsBcc(emailList);
		return RedirectToAction("Snapshot");
	}

public ActionResult EmailNewStudents()
	{
		var beginDate = DateTime.Now.AddDays(-7);
		var newStudents = from student in db.JPStudents
							   where (student.JPStartDate >= beginDate && student.JPStartDate <= DateTime.Now
							   && student.JPHired == false && student.JPGraduated == false)
							   select student.JPEmail;
		string[] emailList = newStudents.ToArray();
		EmailStudentsBcc(emailList);
		return RedirectToAction("Snapshot");
	}

public void EmailStudentsBcc(string[] emailList)
	{
		string bccString = "mailto:?bcc=" + String.Join(",", emailList);
		System.Diagnostics.Process.Start(bccString);
	}