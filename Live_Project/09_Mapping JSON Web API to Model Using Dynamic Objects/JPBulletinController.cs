Before:

 public PartialViewResult _MeetUpApi()
        {
            string[] meetupRequestUrls = {
            @"https://api.meetup.com/techacademy/events?photo-host=public&page=20&sig_id=262155129&sig=9a91a8d626615d7fe8488ceafe098b13c3df1cbb",
            @"https://api.meetup.com/AgilePDX-User-Group-Portland-Metro/events?photo-host=public&page=20&sig_id=262155129&sig=0fab37a6271a33368265477dc6686c684fc13b80",
            @"https://api.meetup.com/DesignOps-Portland/events?photo-host=public&page=20&sig_id=262155129&sig=e7a8a37611d27d2ac62e6bdf99a420c2223bacf9",
            @"https://api.meetup.com/Google-Development-Group-GDG-PDX-Meetup/events?photo-host=public&page=20&sig_id=262155129&sig=37551d316c5000bc0f0b442de509888d241140aa",
            @"https://api.meetup.com/IxDA-Portland/events?photo-host=public&page=20&sig_id=262155129&sig=f622872d8de6266c77bb8301ae0e8799b5ebe47c",
            @"https://api.meetup.com/Meetup-API-Testing/events?photo-host=public&page=20&sig_id=262155129&sig=1eb550ac51038d6bdcdd15469183ea2de4ee3a90",
            @"https://api.meetup.com/Pacific-NW-Software-Quality-Conference-PNSQC/events?photo-host=public&page=20&sig_id=262155129&sig=9d4ce9e1296eba1fd911565c2ed128d955d42ccd",
            @"https://api.meetup.com/Placemaking-in-the-Digital-Age/events?photo-host=public&page=20&sig_id=262155129&sig=73068f0efcd37320a7f28c97e663d562ea14fbe5",
            @"https://api.meetup.com/Portland-Drupal/events?photo-host=public&page=20&sig_id=262155129&sig=99cb6b42d3d736776e5fb59ab49a20628a8de77c",
            @"https://api.meetup.com/Portland-ReactJS/events?photo-host=public&page=20&sig_id=262155129&sig=069893d5e2f5b6c765bc9fe89641bde9b67f8cce",
            @"https://api.meetup.com/PSU-Distinguished-Speaker-Series-at-the-Dept-of-ETM/events?photo-host=public&page=20&sig_id=262155129&sig=22e26a741a41676a005a96493485709bcb39be76",
            @"https://api.meetup.com/alchemycodelab/events?photo-host=public&page=20&sig_id=262155129&sig=1911932731f4370efacf2b49dc60bf550777b162",
            @"https://api.meetup.com/Figma-Portland/events?photo-host=public&page=20&sig_id=262155129&sig=ddcad672881e03e38e12ba1d2bc7f14860721ba9",
            @"https://api.meetup.com/GraphQLPDX/events?photo-host=public&page=20&sig_id=262155129&sig=fad55eb3bfda96d09cc4933a0dcc9b826fd3f57d",
            @"https://api.meetup.com/JAMstack-Portland/events?photo-host=public&page=20&sig_id=262155129&sig=198fdeee9704aff648b0d99215093d9595f09373",
            @"https://api.meetup.com/New-Relic-FutureTalks-PDX/events?photo-host=public&page=20&sig_id=262155129&sig=45ea86b3fb848c5784a6ccc68a7717b112353a63",
            @"https://api.meetup.com/PDX-PHP/events?photo-host=public&page=20&sig_id=262155129&sig=5a8ae0c81d6133887a11453637fc4742b14e70f9",
            @"https://api.meetup.com/Portland-Accessibility-and-User-Experience-Meetup/events?photo-host=public&page=20&sig_id=262155129&sig=7ef13fb641a803041aa44856056de205bbf41176",
            @"https://api.meetup.com/Portland-Programmer-Network/events?photo-host=public&page=20&sig_id=262155129&sig=e2e257ddf2dc8e5fc973615853c300027203a519",
            @"https://api.meetup.com/Portland-Tech-Leadership-Meetup/events?photo-host=public&page=20&sig_id=262155129&sig=166bbafac5c9ecda5a8a589746ceaacd8a78cfb6",
            //Seattle Meetups//
            @"https://api.meetup.com/seattle-api/events?photo-host=public&page=20&sig_id=262073483&sig=fdd82b5d70f3dbf9632fbc129343ca0d7c489695",
            @"https://api.meetup.com/seattlejs/events?photo-host=public&page=20&sig_id=262073483&sig=0916b2797f15c1898f923f050ed0b50d79c4dda2",
            @"https://api.meetup.com/Seattle-WebDev-Coffee/events?photo-host=public&page=20&sig_id=262073483&sig=4a400bd7cc03217d64dee2db42dd4923942e69db",
            @"https://api.meetup.com/seattle-react-js/events?photo-host=public&page=20&sig_id=262073483&sig=ffc34f0a5e8592a3c984a8c78a0d5b7280f0551a",
            @"https://api.meetup.com/Beer-Code-Seattle/events?photo-host=public&page=20&sig_id=262073483&sig=073418eaa6e0f75ee663420edc3e8ae9f1f0c4c6",
            @"https://api.meetup.com/She-Codes-Now-Seattle/events?photo-host=public&page=20&sig_id=262073483&sig=6220a1aff5c02e3e3edc838d954d6fdd9d05a167",
            @"https://api.meetup.com/Seattle-scalability-meetup/events?photo-host=public&page=20&sig_id=262073483&sig=ceb3da5bf759e99278341757b30d8b2d0ca1ef77"
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

            //string dummy = "[{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyxpbhb\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1541451600000,\"local_date\":\"2018-11-04\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":14,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyxpbhb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1540422870000,\"duration\":5400000,\"id\":\"255812101\",\"name\":\"Q.A. Tech Talk with Johnny Reaser\",\"status\":\"upcoming\",\"time\":1541796300000,\"local_date\":\"2018-11-09\",\"local_time\":\"12:45\",\"updated\":1540836573000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":15,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/255812101/\",\"description\":\"<p>Featured Speaker: Johnny Reaser, SR QA Automation Engineer</p> <p>12:45 p.m. Pizza and Refreshments<br/>1:00 p.m. Tech Talk starts</p> <p>Please RSVP</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363672000,\"duration\":10800000,\"id\":\"sdfhfqyxpbqb\",\"name\":\"Intro to HTML & CSS: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1542056400000,\"local_date\":\"2018-11-12\",\"local_time\":\"13:00\",\"updated\":1536363672000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":2,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/sdfhfqyxpbqb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course on Introduction to Web design with HTML &amp; CSS. These languages are used to develop the structure and styling of every website.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of these popular technologies - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyxpbzb\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1542661200000,\"local_date\":\"2018-11-19\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyxpbzb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363672000,\"duration\":10800000,\"id\":\"sdfhfqyxpbjc\",\"name\":\"Intro to HTML & CSS: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1543266000000,\"local_date\":\"2018-11-26\",\"local_time\":\"13:00\",\"updated\":1536363672000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/sdfhfqyxpbjc/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course on Introduction to Web design with HTML &amp; CSS. These languages are used to develop the structure and styling of every website.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of these popular technologies - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyxqbfb\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1543870800000,\"local_date\":\"2018-12-03\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyxqbfb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363672000,\"duration\":10800000,\"id\":\"sdfhfqyxqbnb\",\"name\":\"Intro to HTML & CSS: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1544475600000,\"local_date\":\"2018-12-10\",\"local_time\":\"13:00\",\"updated\":1536363672000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/sdfhfqyxqbnb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course on Introduction to Web design with HTML &amp; CSS. These languages are used to develop the structure and styling of every website.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of these popular technologies - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyxqbwb\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1545080400000,\"local_date\":\"2018-12-17\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyxqbwb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363672000,\"duration\":10800000,\"id\":\"sdfhfqyxqbgc\",\"name\":\"Intro to HTML & CSS: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1545685200000,\"local_date\":\"2018-12-24\",\"local_time\":\"13:00\",\"updated\":1536363672000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/sdfhfqyxqbgc/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course on Introduction to Web design with HTML &amp; CSS. These languages are used to develop the structure and styling of every website.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of these popular technologies - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyxqbpc\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1546290000000,\"local_date\":\"2018-12-31\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyxqbpc/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363672000,\"duration\":10800000,\"id\":\"sdfhfqyzcbkb\",\"name\":\"Intro to HTML & CSS: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1546894800000,\"local_date\":\"2019-01-07\",\"local_time\":\"13:00\",\"updated\":1536363672000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/sdfhfqyzcbkb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course on Introduction to Web design with HTML &amp; CSS. These languages are used to develop the structure and styling of every website.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of these popular technologies - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyzcbsb\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1547499600000,\"local_date\":\"2019-01-14\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyzcbsb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363672000,\"duration\":10800000,\"id\":\"sdfhfqyzcbcc\",\"name\":\"Intro to HTML & CSS: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1548104400000,\"local_date\":\"2019-01-21\",\"local_time\":\"13:00\",\"updated\":1536363672000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/sdfhfqyzcbcc/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course on Introduction to Web design with HTML &amp; CSS. These languages are used to develop the structure and styling of every website.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of these popular technologies - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyzcblc\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1548709200000,\"local_date\":\"2019-01-28\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyzcblc/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363672000,\"duration\":10800000,\"id\":\"sdfhfqyzdbgb\",\"name\":\"Intro to HTML & CSS: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1549314000000,\"local_date\":\"2019-02-04\",\"local_time\":\"13:00\",\"updated\":1536363672000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/sdfhfqyzdbgb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course on Introduction to Web design with HTML &amp; CSS. These languages are used to develop the structure and styling of every website.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of these popular technologies - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyzdbpb\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1549918800000,\"local_date\":\"2019-02-11\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyzdbpb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363672000,\"duration\":10800000,\"id\":\"sdfhfqyzdbxb\",\"name\":\"Intro to HTML & CSS: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1550523600000,\"local_date\":\"2019-02-18\",\"local_time\":\"13:00\",\"updated\":1536363672000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/sdfhfqyzdbxb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course on Introduction to Web design with HTML &amp; CSS. These languages are used to develop the structure and styling of every website.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of these popular technologies - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyzdbhc\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1551128400000,\"local_date\":\"2019-02-25\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyzdbhc/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363672000,\"duration\":10800000,\"id\":\"sdfhfqyzfbgb\",\"name\":\"Intro to HTML & CSS: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1551733200000,\"local_date\":\"2019-03-04\",\"local_time\":\"13:00\",\"updated\":1536363672000,\"utc_offset\":-28800000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/sdfhfqyzfbgb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course on Introduction to Web design with HTML &amp; CSS. These languages are used to develop the structure and styling of every website.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of these popular technologies - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"},{\"created\":1536363913000,\"duration\":10800000,\"id\":\"vffhfqyzfbpb\",\"name\":\"Intro to Python: A Free Coding Class at The Tech Academy\",\"rsvp_limit\":40,\"status\":\"upcoming\",\"time\":1552334400000,\"local_date\":\"2019-03-11\",\"local_time\":\"13:00\",\"updated\":1536363913000,\"utc_offset\":-25200000,\"waitlist_count\":0,\"yes_rsvp_count\":0,\"venue\":{\"id\":23663258,\"name\":\"The Tech Academy\",\"lat\":0.0,\"lon\":0.0,\"repinned\":false,\"address_1\":\"310 SW 4th Ave Suite 230\",\"city\":\"Portland\",\"country\":\"us\",\"localized_country_name\":\"USA\",\"zip\":\"\",\"state\":\"OR\"},\"group\":{\"created\":1455234135000,\"name\":\"Tech Academy Portland Meetup\",\"id\":19556962,\"join_mode\":\"open\",\"lat\":45.52000045776367,\"lon\":-122.66999816894531,\"urlname\":\"techacademy\",\"who\":\"Software Enthusiasts\",\"localized_location\":\"Portland, OR\",\"region\":\"en_US\",\"timezone\":\"US/Pacific\"},\"link\":\"https://www.meetup.com/techacademy/events/vffhfqyzfbpb/\",\"description\":\"<p>We run a code school. We hear from a lot of people we talk to that they're not sure whether they're interested in a job in the tech field, because they don't know enough about it. Sometimes, they've even been told that \\\"programming is hard to learn\\\".</p> <p>At The Tech Academy, we work hard to break down the barriers between people and technology. We think that, with the right approach, anyone can learn to code - and whether you end up working in technology or not, the principles behind coding are useful in a lot of areas.</p> <p>The Tech Academy is offering a free course providing an introduction to Python. Python is a popular programming language for general-purpose programming. It is particularly easy to learn fo those new to coding.</p> <p>This course is perfect for people with little to no experience in programming who are curious about a career in software development.</p> <p>In this practical, hands-on class, you'll learn the basics of this popular computer language - and along the way, you should find out for yourself whether technology and coding are something worth looking into a bit more deeply.</p> <p>The Instructor:<br/>Erik Gross is the co-founder of The Tech Academy, a software developer training school based in Portland, OR. The Tech Academy has helped hundreds of graduates to break into the technology field. Mr. Gross has been a working software developer and consultant for many years, and has developed simple, clear methods for helping nontechnical people genuinely understand technical concepts. He brings an enthusiastic, accessible teaching style to an area of knowledge that all too often leaves people in the dark.</p> <p>Please Note:<br/>---Make sure to bring your laptop, as this will be a hands on learning process where you get to actually write your own code.<br/>---An RSVP is needed to guarantee a seat in the class, though we may have a few open seats for last minute attendees.</p> \",\"how_to_find_us\":\"Join us in our newly remodeled space on the 2nd floor of the Board of Trade Building\",\"visibility\":\"public\"}]";
            //events = ConvertMeetupStringToJPMeetupEvents(dummy);

                        
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

        List<JPMeetupEvent> FilterPastEvents(List<JPMeetupEvent> events)
        {
            var filteredList = new List<JPMeetupEvent>();

            foreach (var meetupEvent in events)
            {
                if (meetupEvent.JPEventDate.CompareTo(DateTime.Now) >= 0)
                {
                    filteredList.Add(meetupEvent);
                }
            }

            return filteredList;
        }

        //will keep the earliest of the duplicates
        List<JPMeetupEvent> FilterDuplicateEvents(List<JPMeetupEvent> events)
        {
            var filteredEvents = new List<JPMeetupEvent>();
            var eventNames = new List<string>();
            foreach (var meetupEvent in events)
            {
                if (!eventNames.Contains(meetupEvent.JPEventName))
                {
                    eventNames.Add(meetupEvent.JPEventName);
                    filteredEvents.Add(meetupEvent);
                }
            }
            return filteredEvents;
        }


        //Sort event dates
        List<JPMeetupEvent> SortDates(List<JPMeetupEvent> events)
        {
            var filteredList = new List<JPMeetupEvent>(events.OrderBy(x => x.JPEventDate));
            return filteredList;
        }


        //filter events by location
        //Modify the logic in the JPBulletins controller that has to do with the 
        //    events pulled from Meetups API to filter the meetups that are shown 
        //    to a user depending on whether they are Seattle(local or remote) 
        //    vs Portland(local or remote)
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

after:

        public PartialViewResult _MeetUpApi()
        {
            DateTime now = DateTime.Now;
            DateTime recently = now.AddHours(-2);
            var updateCheck = db.JPMeetupEvents.Where(x => x.JPDateCreated >= recently);
            if (updateCheck.Count() == 0) // If no events have been added in the last two hours, pull from API.  This throttles how often we request API to prevent lockout.
            {
                string[] meetupRequestUrls = {
                //Portland Meetups//
                @"https://api.meetup.com/techacademy/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/AgilePDX-User-Group-Portland-Metro/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/DesignOps-Portland/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Google-Development-Group-GDG-PDX-Meetup/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/IxDA-Portland/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Pacific-NW-Software-Quality-Conference-PNSQC/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Placemaking-in-the-Digital-Age/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Portland-Drupal/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Portland-ReactJS/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/PSU-Distinguished-Speaker-Series-at-the-Dept-of-ETM/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/alchemycodelab/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Figma-Portland/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/GraphQLPDX/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/JAMstack-Portland/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/New-Relic-FutureTalks-PDX/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/PDX-PHP/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Portland-Accessibility-and-User-Experience-Meetup/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Portland-Programmer-Network/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Portland-Tech-Leadership-Meetup/events?photo-host=public&page=20&page=20",
                //Seattle Meetups//
                @"https://api.meetup.com/seattle-api/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/seattlejs/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Seattle-WebDev-Coffee/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/seattle-react-js/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Beer-Code-Seattle/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/She-Codes-Now-Seattle/events?photo-host=public&page=20&page=20",
                @"https://api.meetup.com/Seattle-scalability-meetup/events?photo-host=public&page=20&page=20",
                //Denver Meetups//
                @"https://api.meetup.com/Denver-Engineering-Leaders/events?&sign=true&photo-host=public&page=20",
                @"https://api.meetup.com/UX-Bookclub-Denver/events?&sign=true&photo-host=public&page=20",
                @"https://api.meetup.com/ReactDenver/events?&sign=true&photo-host=public&page=20",
                @"https://api.meetup.com/DenverUX/events?&sign=true&photo-host=public&page=20",
                @"https://api.meetup.com/colorado-diversity-in-tech/events?&sign=true&photo-host=public&page=20",
                @"https://api.meetup.com/Denver-IASA/events?&sign=true&photo-host=public&page=20",
                @"https://api.meetup.com/Denver-Tech-Design-Community/events?&sign=true&photo-host=public&page=20",
                @"https://api.meetup.com/Develop-Denver/events?&sign=true&photo-host=public&page=20",
                @"https://api.meetup.com/Women-Who-Code-Boulder-Denver/events?photo-host=public&page=20",
                @"https://api.meetup.com/Ladies-that-UX-Denver/events?photo-host=public&page=20",
                @"https://api.meetup.com/Denver-Python-Meetup/events?photo-host=public&page=20",
                @"https://api.meetup.com/Denver-Mock-Programming-Job-Meetup/events?photo-host=public&page=20",
                @"https://api.meetup.com/data-science-women/events?photo-host=public&page=20",
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

                    }

                    //remove old events from table
                    db.JPMeetupEvents.RemoveRange(db.JPMeetupEvents);
                    db.JPMeetupEvents.AddRange(events);

                    db.SaveChanges();

                    //Filter events for current user
                    events = FilterEvents(events);
                }

                //if there is a web exception, load events from the database instead
                //this try/catch block may no longer be necessary because we're controlling API pull frequency in the if/else.
                catch (WebException)
                {
                    events = GetStoredEvents();
                    events = FilterEvents(events);
                }

               return PartialView("_MeetUpApi", events);
            }
            else // If events have been pulled in the last 2 hours, use those events
            {
                var events = GetStoredEvents();
                events = FilterEvents(events);
                return PartialView("_MeetUpApi", events);
            }
        }

        private List<JPMeetupEvent> FilterEvents(List<JPMeetupEvent> events)
        {
            events = FilterDuplicateEvents(events);
            events = FilterLocationEvents(events);
            events = SortDates(events);
            return events;
        }

        private List<JPMeetupEvent> GetStoredEvents()
        {
            List<JPMeetupEvent> events = new List<JPMeetupEvent>();
            foreach (var meetupEvent in db.JPMeetupEvents)
            {
                events.Add(meetupEvent);
            };
            return events;
        }

        public List<JPMeetupEvent> FilterPastEvents(List<JPMeetupEvent> events)
        {
            var filteredList = new List<JPMeetupEvent>();

            foreach (var meetupEvent in events)
            {
                if (meetupEvent.JPEventDate.CompareTo(DateTime.Now) >= 0)
                {
                    filteredList.Add(meetupEvent);
                }
            }

            return filteredList;
        }

        //will keep the earliest of the duplicates
        List<JPMeetupEvent> FilterDuplicateEvents(List<JPMeetupEvent> events)
        {
            var filteredEvents = new List<JPMeetupEvent>();
            var eventNames = new List<string>();
            foreach (var meetupEvent in events)
            {
                if (!eventNames.Contains(meetupEvent.JPEventName))
                {
                    eventNames.Add(meetupEvent.JPEventName);
                    filteredEvents.Add(meetupEvent);
                }
            }
            return filteredEvents;
        }


        //Sort event dates
        List<JPMeetupEvent> SortDates(List<JPMeetupEvent> events)
        {
            var filteredList = new List<JPMeetupEvent>(events.OrderBy(x => x.JPEventDate));
            return filteredList;
        }


        //filter events by location
        //Modify the logic in the JPBulletins controller that has to do with the 
        //    events pulled from Meetups API to filter the meetups that are shown 
        //    to a user depending on whether they are Seattle(local or remote) 
        //    vs Portland(local or remote)
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
            else if (StudentLocation == "DenverLocal" || StudentLocation == "DenverRemote")
            {
                StudentLocation = "Denver";
            }
            else
            {
                StudentLocation = "Portland";  // Setting a default of Portland if no location comes through.
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