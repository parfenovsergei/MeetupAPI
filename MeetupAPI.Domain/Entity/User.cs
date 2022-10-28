using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.Domain.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        [ForeignKey("OrganazerId")]
        public virtual List<Meetup> OrganizedMeetups { get; set; } = new List<Meetup>();

        [ForeignKey("SpeakerId")]
        public virtual List<Meetup> SpeakerMeetups { get; set; } = new List<Meetup>();
    }
}
