### Using Radio Buttons to Change Form Action and Pass Parameters to Controller

That's a mouthful!  But that's about as close to summarizing what I did in a single sentence as I can get.  So, if you've looked at some of my other stories from this project you will find a UpdateAndBcc function I made to recieve an email list from the View, pass it through some existing functions in the Controller that ensured updated email addresses are pulled from the database, and then send the list to a mail client.  It turns out that concurrently someone was working on a piece of JavaScript that would take a selected radio button (applying or graduating) and send a pre-written body text along with the email list.

Since we were working on it at the same time, their code didn't call my function and nothing was actually being passed through the controller, hence updated email addresses were not being used.  That's a problem!  Originally the issue had been pushed back to me because when you clicked "Send Email" it would redirect you back to the same page making it so you couldn't see the radio buttons that appeared before the page refreshed.  But really, my button should no longer have been a submit form button anyway because there were some more choices that should happen before that step.  So first things first, I removed all form functionality from my original button.

### Original:

```html
<form style="display: inline" action="mailto:?bcc=@emailList" method="post">
	<button class="btn btn-primary">Email Students</button>
</form>
```
###Removing Form:
 ```html
<button class="btn btn-primary" id="email-students" type="button">Email Students</button>
```

I added an id so I could target it to make the radio buttons expand and collapse.  I had to make some small changes to the form.

### Original form:

```html
<div id="email-students-popup">
	<h6>What is your email in regards to?</h6>
	<form>
		<input type="radio" name="email" value="graduating"/>Graduating<br />
		<input type="radio" name="email" value="applying"/>Applying<br />
		<button class="btn btn-primary"id="email-students-submit" type="button">Submit</button>
	</form>
</div>
```

### My changes:

```html
<div id="email-students-popup">
	<h6 class="mt-2">What is your email in regard to?</h6>
	<form id="submit-form" method="post">
		<input type="radio" name="email" value="graduating" checked="checked" />Graduating<br />
		<input type="radio" name="email" value="applying" />Applying<br /><br />
		<button class="btn btn-primary" type="submit" id="submit-button">Submit</button>
	</form>
</div>
```

Here I essentially ensured that the method was "post" which was needed for sending the emailList to the email client, and I added an id so I could target the form's submit action later.  I also changed the button type to submit.  The original radio buttons didn't have a default value so I went ahead and selected one because it's better to control that here than to write extra code later for the case of a null value.

Next came modifying the JavaScript.  The original code, to be honest, did not work.  I don't know how it got a pass.  Take a look:

### Original Code:

```html
<script type="text/javascript">
	$("#email-students-popup").hide();
	$("form#email-students").click(function () {
		$("#email-students-popup").show();
	});
	$("#email-students-submit").click(function () {
		var radioValue = $("input[value='graduating']:checked").val();
		var radiValue2 = $("input[value='applying']:checked").val();
		if (radioValue) {
			window.open('mailto:?bcc=@emailList?&body=Graduating');
		}
		else if (radiValue2) {
			window.open('mailto:?bcc=@emailList?&body=Applying');
		}
		else {
			alert("Please select an option.");
		}
	});
</script>
```

So first, the hide/show functionality I personally hate.  If a button makes something appear, it should be able to hide it too!  So I channged that to be a toggle.  Also, because I was having significant difficulty tracking down why the page was refreshing before I changed my approach to embrace the refresh (for now) I separated the hide/show functionality from the radio button functionality.  Next, look at the code for the radioValue and radiValue2 (sic).  They're being targeted by their values and then having those values assigned to a variable? It must have been returning some sort of value, because no matter what you clicked you would get the &body=Graduating text, so radioValue was always "true" as it were.  I the JS was sweating in the background trying to determine what kind of variable radioValue needed to be.  This would NOT have compiled at all in a strong-typed language.  But I digress, I had to fix the issues and make it call my function!

### Andrew To The Rescue:

```html
<!-- JS to toggle radio options when email button clicked-->
<script type="text/javascript">
	$("#email-students-popup").hide();
	$("#email-students").click(function () {
		$("#email-students-popup").toggle();
	});
</script>

<!-- JS for Sending Email -->
<script type="text/javascript">
	var radioInput = "default"
	$("#submit-form").submit(function () {
		radioInput = $("input[name='email']:checked").val();
		if (radioInput == "graduating") {

				$("#submit-form").attr("action", "@Html.Raw(@Url.Action("UpdateAndBcc", "JPStudentRundown", new { emailList = emailList , body = gradBody }))" );
				document.getElementById("submit-email").submit();
			}
			else if (radioInput == "applying") {
				$("#submit-form").attr("action", "@Html.Raw(@Url.Action("UpdateAndBcc", "JPStudentRundown", new { emailList =emailList, body = applyBody }))" );
				document.getElementById("submit-email").submit();
			}
			else {
				alert("Something went wrong");
			}
	});

</script>
```

First you may notice the convenient labels added for debugging in Chrome.  It's a whole lot easier to pull up and look at your code with those!  Also we now have a .toggle function instead of .show for cleaning up the screen on those accidental clicks.  In the JS for sending email I had to define the variable for the radio button outside of the click function so that both branches of my if could use the same variable name.  Next I targeted the submit action of the form, had it assign the value of the checked radio button at that point then perform an action based on the result.  Inside my if statments I used JQuery to add an action attribute to the form tag that would cause generate URL that would pass the needed parameters over to my function in the controller.  The tricky thing is, you can't send a JavaScript variable into your Razor syntax.  This is because the Razor syntax is carried out by the server when the page is requested and sent.  It's done compiling before you can click on anything and cannot be dynamically generated after the page has begun.  So I had to pre-define the desired results in the HTML above.  I added:

### Razor Syntax Variables:
@{
	int strLength = emailList.Length;
	emailList = emailList.Substring(0, (strLength - 1)); //removes last comma
 }
 
 @{
        // TODO: Assign real body text here. Perhaps make a function to convert .txt to string so in the future putting a .txt in the right file will change the content?
        string gradBody = "&body=Graduating%20Text";
        string applyBody = "&body=Applying%20Text";
    }

So the first part addressed an issue where the emailList was created by concatenating with a "," at the end of each item.  That comma would through off appending any body text, so I added the code there to remove the trailing comma.  Second, I defined the text that would be sent over for graduating and applying using some placeholders.  Now if you look back to the JavaScript above you'll see that I assign body as either gradBody or applyBody based on the radio option selected in my if/else.  Now we're in business.  Kind of.  I had to modify my function to take to parameters.  I also went ahead and removed some code I added to SendMail that controlled for the commas at the end previously since I changed that above at the source.

### Old Code:

```cs
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

```

### New Code:

```cs
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

[HttpPost]
	public ActionResult UpdateAndBcc(string emailList, string body)
	{
		//Calls the SendMail function above to ensure latest contact info is used then sends the updated list to email app as BCC.
		
		var mailingList = SendMail(emailList);
		string mailString = "mailto:?bcc=";
		string[] compileEmail = mailingList.ToArray();
		mailString += String.Join(",", compileEmail); //Using an array plus String.Join avoids a trailing comma.
		mailString += body;
		System.Diagnostics.Process.Start(mailString);
		return RedirectToAction("Index");
		//In the future if this call is made via Ajax and no return is needed, just delete return and change type to void.
	}
```

It works!  Since the original issue had been presented to me as having my function redirect before the radio buttons could be used, this now avoids that.  I really wanted to figure out how to make this function be called Async and not have the page refresh at all.  But, it took me a long time to arrive finally at this solution and it does the job.  If the async call is important to the project I might be revisiting this one more time, otherwise it may not be worth my time to do so.  I might try it as an exercise later though!


