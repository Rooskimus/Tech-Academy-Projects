// Before:

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
		
// After:

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

            return listOfEmails;
        }

        public void UpdateAndBcc(string emailList)
        {
            //Calls the SendMail function above to ensure latest contact info is used then sends the updated list to email app as BCC.
            var mailingList = SendMail(emailList);
            string mailString = "mailto:?bcc=";
            string[] compileEmail = mailingList.ToArray();
            mailString += String.Join(",", compileEmail); //Using an array plus String.Join avoids a trailing comma.
            System.Diagnostics.Process.Start(mailString);
        }