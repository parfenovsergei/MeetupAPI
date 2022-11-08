namespace MeetupAPI.Domain.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual List<Meetup> OrganizedMeetups { get; set; } = new List<Meetup>();
        public virtual List<Meetup> SpeakerMeetups { get; set; } = new List<Meetup>();
    }
}
