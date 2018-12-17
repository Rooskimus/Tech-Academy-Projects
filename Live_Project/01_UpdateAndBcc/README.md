# Adding Two Methods to One Form Button

A story I chose to tackle involved making a button that sends emails to a list of mailing addresses call a function that ensures the latest updated email information is pulled and then mails the list as a BCC.  It was a great opportunity to get some practice in HTML, MVC, and C#.  The original code was simply done in HTML:

### Before:
'''cshtml
 <form style="display: inline" action="mailto:?bcc=@emailList" method="post">
        <button class="btn btn-primary">Email Students</button>
</form>
'''

I decided my approach would be to create a new subroutine in the controller that performs both actions desired and call that.  My HTML portion became:
		
### After:

'''cshtml
<form style="display: inline" action="@Url.Action("UpdateAndBcc", new { emailList })" method="post">
        <button class="btn btn-primary">Email Students</button>
</form>
'''

It honestly took me a while to find good way to hit the desired action in the controller and pass the parameter needed!  Sometimes things that sound simple can be a little complicated, but most of the time it comes down to knowledge of syntax and how to manipulate it.  I'm learning all the time.

Next, I had to create my "UpdateAndBcc" subroutine in the controller.  I ended up with:

### UpdateAndBCC Function:

'''cs
public void UpdateAndBcc(string emailList)
        {
            //Calls the SendMail function above to ensure latest contact info is used then sends the updated list to email app as BCC.
            var mailingList = SendMail(emailList);
            string mailString = "mailto:?bcc=";
            string[] compileEmail = mailingList.ToArray();
            mailString += String.Join(",", compileEmail); //Using an array plus String.Join avoids a trailing comma.
            System.Diagnostics.Process.Start(mailString);
        }
'''

Again, I had to look into syntax in order to make this work.  I tried creating my mailString a few different ways, but I liked this one the best because it avoided iterating and automatically avoided trailing commas.  No delta statement for removing characters from strings necessary!  However, along that line there was an issue.  In the Index.cs file where the emailString is created, they use a simple concatenation with a + "," in a foreach loop, so there ended up being a trailing comma.  They then use emailString.Split(",") to create a list for the SendMail function which then recieved a null value for the final email in the list because there was nothing after the final comma in emailString.  So I had to add an if/else loop to SendMail to remove the null email.

### SendMail Before:

'''cs
public List<string> SendMail(string emailList)
        {
            List<string> listOfEmails = emailList.Split(',').ToList();
            foreach (var emailName in listOfEmails)
            {
                //Takes each email in list and searches for it on the JPStudents table and finds the associated ApplicationUserID.
                //Then calls the UpdateLatestContact method on each ApplicationUserID.
                var userId = db.JPStudents.Where(x => x.JPEmail == emailName).First().ApplicationUserId.ToString();
                UpdateLatestContact(userId);
            }

            return listOfEmails;
        }
'''

### Sendmail After:

'''cs
public List<string> SendMail(string emailList)
        {
            List<string> listOfEmails = emailList.Split(',').ToList();
            foreach (var emailName in listOfEmails)
            {
                //Takes each email in list and searches for it on the JPStudents table and finds the associated ApplicationUserID.
                //Then calls the UpdateLatestContact method on each ApplicationUserID.
                //The if/else controls for concatenating algorithm in Index leaving an ending "," and causing an empty item in the list when split above.
                if (emailName == "")
                {
                    listOfEmails.Remove(emailName);
                    break;
                }
                else
                {
                    var userId = db.JPStudents.Where(x => x.JPEmail == emailName).First().ApplicationUserId.ToString();
                    UpdateLatestContact(userId);

                }
            }
'''

Success!  I always feel stupidly proud when I finally figure out an issue and make things work.  So thank you for reading this and letting me share my code with you.