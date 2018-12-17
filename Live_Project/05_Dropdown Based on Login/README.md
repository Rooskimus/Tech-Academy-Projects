#Navbar Options based on Login Authentication

This was another story I wanted to tackle because it sounded tougher than it really was due to having already been implemented in the code.  Basically, there were two options, "Log Data" and "MyApplications" that needed to only appear when a student was logged in to a page.  So, I located the partial view that contained the navbar and found those elements in a set of list tags.  All I had to do was wrap them in an if statment:

###Before:
'''cshtml
<li id="JPDropDown">
	<a href="#">Job Placement</a>
	<ul class="sub-menu">
		<li class="job-placement-dropdown-item">Student Dashboard</li>
		<li class="JPDropDown">@Html.ActionLink("Home", "Analytics", "Analytics")</li>
		<li class="JPDropDown">@Html.ActionLink("Create an Account", "Create", "JPStudents")</li>
		<li class="JPDropDown">
			<a href="#">Log Data</a>
			<ul class="sub-menu">
				<li class="JPDropDownSub">@Html.ActionLink("Applications", "Create", "JPApplications")</li>
				<li class="JPDropDownSub">@Html.ActionLink("Offer", "Create", "JPHires")</li>
				<li class="JPDropDownSub">@Html.ActionLink("Current Employment", "Index", "JPCurrentJobs")</li>
			</ul>
		</li>
		<li class="JPDropDown">@Html.ActionLink("Networking", "Networking", "Networking")</li>
		<li class="JPDropDown">@Html.ActionLink("Bulletin", "Index", "JPBulletins")</li>
		<li class="JPDropDown">@Html.ActionLink("My Applications", "StudentIndex", "JPApplications")</li>
'''					

###After:

'''cshtml
<li id="JPDropDown">
	<a href="#">Job Placement</a>
	<ul class="sub-menu">
		<li class="job-placement-dropdown-item">Student Dashboard</li>
		<li class="JPDropDown">@Html.ActionLink("Home", "Analytics", "Analytics")</li>
		<li class="JPDropDown">@Html.ActionLink("Create an Account", "Create", "JPStudents")</li>
		<li class="JPDropDown">@Html.ActionLink("Networking", "Networking", "Networking")</li>
		<li class="JPDropDown">@Html.ActionLink("Bulletin", "Index", "JPBulletins")</li>
		@if (User.Identity.IsAuthenticated)
		{
		<li class="JPDropDown">
			<a href="#">Log Data</a>
			<ul class="sub-menu">
				<li class="JPDropDownSub">@Html.ActionLink("Applications", "Create", "JPApplications")</li>
				<li class="JPDropDownSub">@Html.ActionLink("Offer", "Create", "JPHires")</li>
				<li class="JPDropDownSub">@Html.ActionLink("Current Employment", "Index", "JPCurrentJobs")</li>
			</ul>
		</li>
		<li class="JPDropDown">@Html.ActionLink("My Applications", "StudentIndex", "JPApplications")</li>
		}
'''

Because MVC already includs a property for checking authentication, I just had to call it as you see above.