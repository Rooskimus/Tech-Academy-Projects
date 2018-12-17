# Back To List Button

I felt that I had been doing a lot of back-end type stories and that for the sake of demonstrating and sharpening all of my programming ability I should do a front-end story.  Besides, it should be easy and I could knock out a few in a row pretty quickly, right?  Well, front end can be just as confusing as back end!  When you're dealing with a complex MVC site such as this project, the inheritance of styling properties for any given element can be really tricky to track down.  Such was the case with this user story.

My objective was simple: change the "back to list" link into a button and place it in line with the Save button.  So I found the link tag and modified it to be a button but there was a problem immediately.  Well, two problems really.  First, the link wasn't correct.  It didn't take you back to the list of job applications intended at all, it redirected you to a page asking you to log in even though you could clearly see that you were still logged in in the top-right navbar.  Also, the button didn't line up with the Save button at all.

Fixing the link was easy enough, just make the target href hit the controller and method desired.  But, having changed the link into a button, even with type="button" (not type="submit") it would cause the form to submit and redirect differently based on a different method being called in the controller.  When I moved the button outside of the Razor-generated form tags, it no longer functioned at all.  

So what about a link with button styling?  I went back to the <a> tag format and fed in the bootstrap classes to make it look like a button and viola, it looked like a button!  Except...the text inside the button wasn't vertically aligned the same as the other button.  When it was in button form there hadn't been an issue with the text.  I figured there was some property the button was inheriting that the link was not, but when I tried adding a few different properties that should have made the link text move, it did not.  I scoured through a number of CSS and Bootstrap files looking for what property this <a> tag could possibly have inherited the keep the text glued the to top of the button.  I used the Chrome Dev Tools to disable inherited properties one by one to no avail.

So I gave up on the link tag, back to a button!  The button's issue was one of on-click functionality.  Luckily, that's something that we can add with a few choice lines of JavaScript.  After a little research and trial and error, I was able to get the button working.  Now, to make it line up and ideally be responsive.  I tried a lot of things here, but what I ended up going with was the "col-sm-3" class from Bootstrap.  I didn't know why, but other column classes wouldn't make it budge.  A while after I had originally written this, I noticed that there is a parent tag that uses the col-sm-10 class above.  So possibly the restriction lay there.  Regardless, I wasn't able to manipulate the buttons quite as I would like to have done when it came to scaling the screen size down.  At leasting using "form-control" and "form-group" classes I was able to make them stack and be the same size on smaller screens.  I wanted a  space between them but couldn't override whatever was locking them in place.  It functions and it looks OK, and that kind of styling was beyond the scope of my user story anyway.  So here's the code:

### Original Code (Relevant Snippet):

```cshtml
	@using (Html.BeginForm())
	{
	   [lots of other table elements]
	   <div>
                <div class="form-group" id="inline1">
                    <div class="col-md-10">
                        <input type="submit" value="Save" class="btn btn-default" />
                    </div>
                </div>
            </div>
        }

        <div>
            @Html.ActionLink("Back to List", "Index")
        </div>

    </div>
</div>
```

### My Changes

```cshtml
	@using (Html.BeginForm())
	{
	   [lots of other table elements]
	   <div class="form-group" id="inline1">
                    <div class="col-sm-3">
                        <input type="submit" value="Save" class="btn btn-default form-control" />
                    </div>
                    <div class="col-sm-4">
                        <button type="button" class="btn btn-default form-control" id="BackToList">Back to List</button>
                    </div>
                </div>
            </div>
        }

<script type="text/javascript">
    document.getElementById("BackToList").onclick = function () {
        window.location.assign("@Url.Action("StudentIndex", "JPApplications")")
    }
</script>
```

Thanks for following along!
