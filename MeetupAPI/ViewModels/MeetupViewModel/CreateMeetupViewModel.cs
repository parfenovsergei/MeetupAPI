namespace MeetupAPI.ViewModels.MeetupViewModel
{
    public class CreateMeetupViewModel
    {
        public string MeetupName { get; set; }
        public string Description { get; set; }
        public DateTime MeetupDate { get; set; }
        public string MeetupLocation { get; set; }
        public string SpeakerEmail { get; set; }
    }
}
