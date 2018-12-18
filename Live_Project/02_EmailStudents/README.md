# Change Functionality from Create .csv File to BCC Email List

This user story involved taking a button in a .cshtml file and changing the functionality so that it would email a list of students rather than exporting a .csv file.  It was relatively straight-forward though, as with anything, there were a few small points that I had to research how to handle.  All of the query statements that grab the items from the database were modified from the original ExportCSV function which only had the new and weekly functionality programmed in.  The approach I took was to add a button for each time-frame (monthly, yearly, etc.) and have it call a function with that name that performs the database operation.  First I added the buttons to the .cshtml file:

### Add CSHTML:

```cshtml
@Html.ActionLink("Email Students", "EmailWeeklyStudents", null, new { @class = "btn btn-primary" })
 
@Html.ActionLink("Email Students", "EmailMonthlyStudents", null, new { @class = "btn btn-primary" })
  
@Html.ActionLink("Email Students", "EmailYearlyStudents", null, new { @class = "btn btn-primary" })

@Html.ActionLink("Email Students", "EmailNewStudents", null, new { @class = "btn btn-primary", @id = "spaceFoot" })
```

Of course those buttons went to the correct location in the appropriate tables, not in a list as shown above.  The weekly and new buttons existed already so I used them as templates and modified them from there.  Next, I created the associated functions in the Controller.

### Adding Data-pulling and Emailing Subroutines:

```cs

public void EmailStudentsBcc(string[] emailList)
	{
		string bccString = "mailto:?bcc=" + String.Join(",", emailList);
		System.Diagnostics.Process.Start(bccString);
	}

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
```

If you looked at my code for the UpdateAndBcc function I did earlier, you'll notice that the way I convert the emailList to a string from an array is the same.  The thing that oddly took me a while to figure out was the return RedirectToAction!  I was trying to use return View() with a number of variations and it just wasn't working right. Even when I tried to specify a relative location back to Snapshot the site threw an unhandled exception.  So I started poking through some of the other functions and saw the RedirectToAction in another controller and realized it was the perfect solution.  I should have remembered that one, but sometimes we get so stuck in trying to make the solution you *think* will work work that you forget to consider other options.  Lesson learned, and now we have another good block of functioning code for the project.
