# Mapping JSON Web API Data to Local Model

This user story went down the rabbit hole in a big way.  I chose it because I had never dealt with APIs and it seemed like a good introduction.  I was supposed to go to the meetup.com API page and generate APIs for some meetup groups in the Denver area, then modify the location filter method in the controller so that if the student was from the DenverLocal or DenverRemote areas it would automatically populate the meetup partial view with meetup events from the Denver area.  Notice that my title above has little to do with that!  We'll get to that in a moment.  Just to demonstrate efficiency, I wanted to note how quickly I resolved the user story itself.

First I navigated to the api.meetups.com site and read through the page to figure out what and how exactly I needed to generate the API urls.  All of the API urls in our code at this point were signed, so I ended up generating a bunch of signed APIs too and adding them to the list.  It's a big chunk of code that we don't really need to see here.  You can see what I ended up adding in the JPBulletinController.cs file above if you'd like.

Next I found the needed method in the controller, FilterLocationEvents.  I added another "else if" statement following the pattern that was already present for the other cities as well as an else statement to cover any situation where the data passed to the controller lacked location data for the user.  I chose to default them to Portland since that's where the Tech Academy is headquartered.

### Original Code:

```cs
List<JPMeetupEvent> FilterLocationEvents(List<JPMeetupEvent> events)
        {
            // Determine Location of User
            var UserId = User.Identity.GetUserId();
            var StudentLocation = db.JPStudents.Where(x => x.ApplicationUserId == UserId).Select(x => x.JPStudentLocation).FirstOrDefault().ToString();
                        
            if (StudentLocation == "PortlandLocal" || StudentLocation == "PortlandRemote")
            {
                StudentLocation = "Portland";
            }
            else if (StudentLocation == "SeattleLocal" || StudentLocation == "SeattleRemote")
            {
                StudentLocation = "Seattle";
            }


            // Filter event location by user location
            var filteredEvents = new List<JPMeetupEvent>();

            foreach (var meetup in events)
            {           
                if (meetup.JPLocation == StudentLocation)
                {
                    filteredEvents.Add(meetup);
                }
            }
            return filteredEvents;
        }
```

### My Addition:

```cs
else if (StudentLocation == "DenverLocal" || StudentLocation == "DenverRemote")
            {
                StudentLocation = "Denver";
            }
            else
            {
                StudentLocation = "Portland";  // Setting a default of Portland if no location comes through.
            }
```

Perfect!  So now all we need to do is test it with a Student at a Denver location.  So I dug through the student tables and found one.  Then I spun up the solution and logged in as a Denver student and gave it a go and...a Portland event came up.  Just ONE Portland event too, which is odd considering how many API requests we had in there.  So I was guessing the catch block was being activated in the MeetupApi method.  Since I'll be referring to it a lot, here it is:

### MeetUpApi Original Code:

```cs
public PartialViewResult _MeetUpApi()
        {
            DateTime now = DateTime.Now;
            DateTime recently = now.AddHours(-2);
            var updateCheck = db.JPMeetupEvents.Where(x => x.JPDateCreated >= recently);
            if (updateCheck.Count() == 0) // If no events have been added in the last two hours, pull from API.  This throttles how often we request API to prevent lockout.
            {
                string[] meetupRequestUrls = {
                [Long list of API Url's; if you want to view the full list check out the file itself]
                };

                var events = new List<JPMeetupEvent>();
                try
                {
                    var responseStrings = new List<string>();
                    foreach (var url in meetupRequestUrls)
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        using (Stream stream = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            responseStrings.Add(reader.ReadToEnd());
                        }
                    }

                foreach (var str in responseStrings)
                {
                    events.AddRange(ConvertMeetupStringToJPMeetupEvents(str));
                }
                events = FilterPastEvents(events);
                events = FilterDuplicateEvents(events);
                events = FilterLocationEvents(events);
                events = SortDates(events);

                //remove old events from table
                db.JPMeetupEvents.RemoveRange(db.JPMeetupEvents);
                db.JPMeetupEvents.AddRange(events);

                db.SaveChanges();
            }

            //if there is a web exception, we need to load events from the database instead
            catch (WebException)
            {
                foreach (var meetupEvent in db.JPMeetupEvents)
                {
                    events.Add(meetupEvent);
                }
                    events = FilterPastEvents(events);
            }
            return PartialView("_MeetUpApi", events);
        }
        
        List<JPMeetupEvent> ConvertMeetupStringToJPMeetupEvents(string meetup)
        {
            var events = new List<JPMeetupEvent>();
            var meetupSB = new StringBuilder(meetup);            
            while (true)
            {
                var meetupEvent = new JPMeetupEvent();

                int nameIndex = meetupSB.ToString().IndexOf("\"name\"");
                if (nameIndex == -1) break;
                meetupSB.Remove(0, nameIndex + 8);
                int commaIndex = meetupSB.ToString().IndexOf(",");
                meetupEvent.JPEventName = meetupSB.ToString().Substring(0,commaIndex - 1);

                int dateIndex = meetupSB.ToString().IndexOf("\"local_date\"");                
                meetupSB.Remove(0, dateIndex + 14);
                commaIndex = meetupSB.ToString().IndexOf(",");
                var date = DateTime.Parse(meetupSB.ToString().Substring(0, commaIndex - 1));
                meetupEvent.JPEventDate = date;

                int locationIndex = meetupSB.ToString().IndexOf("\"city\"");
                meetupSB.Remove(0, locationIndex + 8);
                commaIndex = meetupSB.ToString().IndexOf(",");
                meetupEvent.JPLocation = meetupSB.ToString().Substring(0, commaIndex - 1);

                int linkIndex = meetupSB.ToString().IndexOf("\"link\"");              
                meetupSB.Remove(0, linkIndex + 8);
                commaIndex = meetupSB.ToString().IndexOf(",");
                meetupEvent.JPEventLink = meetupSB.ToString().Substring(0, commaIndex - 1);



                events.Add(meetupEvent);
            }


            return events;
        }
```

Something was giving a WebException error and causing that catch block to go.  So, I set break points all over the controller and ran the site in debug mode.  The first error I got was with the signed APIs.  It told me I didn't have the authority to pull those APIs.  After reading about it, I learned that a signed API attaches your personal account to the API request.  So it would be pulling my personal login's view of a meetup.  I think the issue was that someone else had put in signed APIs before, so when it reached my signed APIs suddenly it was pulling for a different user and it didn't like that.  Realizing that there was no need to have this attached to my personal Meetup account, I ditched the signed version.  I had to do some quick research on a lambda function that would let me delete everything after a certain character and then performed a find and replace operation to make the change.  This was MUCH faster than going to the site and pulling each unsigned request manually or manually making the changes in the urls.

With the breakpoints in place, I tried again.  This time I got through making the API requests, but when the ConvertMeetupStringToJPMeetupEvents method was called, it was doing some funny things.  First, the obvious, it was throwing an error.   At some point it was trying to parse a date from the string and it was finding an "unrecognized word" instead.  So I had to sit down and really look at what that method was doing.  It was taking the response string from the API, searching for keywords using a stringbuilder and slicing out the information from the string using those keywords and trailing commas.  It looked like someone did a lot of hard work getting this chunk of code working.  So why was it giving an error?  Well, I looked at the data just before the error was thrown.  It had created a JPMeetupEvent with a name which was one of the event groups, not the event itself.  So I looked at the API data.  Each response string has a name in at least three spots: the event, the group, and the venue.  The group and venue, of course, didn't have associated dates, so after the event was being added this method had no way of knowing what data to skip in order to get to the next event.

This meant that this section of code *never worked* in the first place.  Scrolling around I saw that they had been testing with a commented-out "dummy string" which is the one event that loaded from the catch block.  The problem with the dummy string is it didn't actually look like the response string from the API.  No bueno!  You can't test something unless you make your test model as accurate to the real model as possible.  Looking at the response string, I knew there would be no way to easily parse the string data in this manner and get just the info we wanted.  But it looked to me like the response strings were coming in a defined format of some sort.  I just needed to figure out what that format is and how to translate that into something we could use.

It didn't take much googling to figure out that the data recieved was in JSON format.  A little more research revealed that there are libraries for converting JSON data into C# objects.  The examples I was getting all involved creating a model that matched the incoming JSON data and then mapping it that way.  The only issue was, we didn't really need to save ALL of the data coming in to our database.  In fact, we didn't really want a model based on the JSON data at all.  We just needed the few properties we already had in the JPMeetUpEvent class.  Also, I didn't want to make a model with as many properties as the data we were recieving had.  It would take a long time!  So I poked around about auto-generating a model and came across dynamic objects.  They take the data coming in and create a *temporary* object at runtime automatically with properties based on the incoming JSON data.  It was perfect!  

### Dynamic Objects FTW:

```cs
foreach (var jsonString in responseStrings)  // This loop takes the Json information in the strings, converts them into dynamic objects and extracts meetup info from those objects.
                    {
                        dynamic meetupDynamic = System.Web.Helpers.Json.Decode(jsonString);  // Decodes JSON string into a dynamic object that automatically generates properties.
                        int jsonObjectCount = meetupDynamic.Length;
                        for (int i = 0; i < jsonObjectCount; i++)  // This loop gets the JPMeetupEvent data from the dynamic class.
                        {
                            JPMeetupEvent jpEvent = new JPMeetupEvent()
                            {
                                JPEventName = meetupDynamic[i].name,  // The .name, .link, etc are the property names assigned by the decoder based on the JSON API string.
                                JPEventLink = meetupDynamic[i].link,
                                JPEventDate = Convert.ToDateTime(meetupDynamic[i].local_date + " " + meetupDynamic[i].local_time),
                                JPDateCreated = now                                
                            };

                            try  // If no city has been selected for the event, no venue.city property is created and an error is thrown.
                            {
                                jpEvent.JPLocation = meetupDynamic[i].venue.city;
                            }
                            catch  // Get city from API group info instead.
                            {
                                string city = meetupDynamic[i].group.localized_location; // This comes in City, ST format and needs parsing.
                                city = city.Substring(0, city.LastIndexOf(","));
                                jpEvent.JPLocation = city;
                            }
                            
                            events.Add(jpEvent);
                        };
```

The library for making dynamic objects (Newtonsoft.Json) is beautifully simple, just one line of code.  Using it allowed me to remove that whole "ConvertMeetupStringToJPMeetupEvents" method.  Then I had to make a loop to go through each response string and pull out the events.  They were indexed very simply 0 to however many existed, so I created the for loop based on the length of the dynamic object.  I added a few comments along the way because I figure a lot of the other students who will be working on this in the future will never have seen dynamic objects or JSON data before.  I hadn't either!  And yet, I was still getting an error getting the city out of the venue.  It turned out that if there wasn't a venue selected, the dynamic object didn't generate the venue.city property at all and the program had no idea what is was looking for.  Hence the try/catch block I added.  If there were any errors getting the venue's city, the group always had a city attached to it which just needed a little parsing to remove the state.

This whole chunk of code may be eligible to become its own method, but because we only want to do this when we pull new API requests and we only want to do that every so often so as not to get locked out by the server I felt it was best to leave it within the MeetUpApi method.

Speaking of which, we also wanted to make sure not to get locked out of the Meetup API site for pulling too often!  From the site documentation, it looked like there was an hourly limit.  I figured pulling the data once every two hours at a maximum would be sufficient for our purposes.  So I added at the top an if/else statement that would check our stored events for when they were created and only pull again if it had been over two hours.  I had to add a DateCreated property to our JPMeetupEvent model in order to do so, and run a code Migration to update the database table, plus I modified the seed data just to be thorough.  You can see he property being added in the file itself if you like.

And there you have it, the way we pulled and mapped the API data was completely revamped, functioning, and limited so we wouldn't get locked out.  The code I had put in initially for the Denver area worked perfectly.  I also noticed the API doesn't give past events, so I didn't include the FilterPastEvents method in my FilterEvents method which I added for brevity.  I realize now that it should be included in my GetStoredEvents method just in case.  Since the APIs should be pulled every two hours, it may be a little redundant.  But, if the big catch block is activated for any reason it may streamline things.  I'll email the project lead about that though!  No one's perfect I guess, and that illustrates why it can be value to do a write-up like this on your code.

Anyway, there you have it.  I took a basic user story, realized a fundamental flaw in the logic being used and corrected it.  I felt very proud of this one.
