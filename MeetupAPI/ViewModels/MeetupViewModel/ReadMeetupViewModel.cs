namespace MeetupAPI.ViewModels.MeetupViewModel
{
    public class ReadMeetupViewModel
    {
        public int MeetupId { get; set; }
        public string MeetupName { get; set; }
        public string Description { get; set; }
        public DateTime MeetupDate { get; set; }
        public string MeetupLocation { get; set; }
        public string OrganizerEmail { get; set; }
        public string SpeakerEmail { get; set; }
    }
}
