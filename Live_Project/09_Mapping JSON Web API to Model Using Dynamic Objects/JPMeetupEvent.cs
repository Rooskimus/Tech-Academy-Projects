Before:

namespace JobPlacementDashboard.Models
{
    public class JPMeetupEvent
    {
        [Key]
        [DisplayName("Event Id")]
        public int JPEventId { get; set; }
        [DisplayName("Event Name")]
        public string JPEventName { get; set; }
        [DisplayName("Event Link")]
        public string JPEventLink { get; set; }
        [DisplayName("Event Date")]
        public DateTime JPEventDate { get; set; }
        [DisplayName("Location")]
        public string JPLocation { get; set; }

    }
}


After:

namespace JobPlacementDashboard.Models
{
    public class JPMeetupEvent
    {
        [Key]
        [DisplayName("Event Id")]
        public int JPEventId { get; set; }
        [DisplayName("Event Name")]
        public string JPEventName { get; set; }
        [DisplayName("Event Link")]
        public string JPEventLink { get; set; }
        [DisplayName("Event Date")]
        public DateTime JPEventDate { get; set; }
        [DisplayName("Location")]
        public string JPLocation { get; set; }
        [DisplayName("Date Created")]
        public DateTime JPDateCreated { get; set; }

    }
}