using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.Domain.Entity
{
    public class Meetup
    {
        public int MeetupId { get; set; }
        public string MeetupName { get; set; }
        public string Description { get; set; }
        public DateTime MeetupDate { get; set; }
        public string MeetupLocation { get; set; }
        public int OrganizerId { get; set; }
        public virtual User Organizer { get; set; }
        public int SpeakerId { get; set; }
        public virtual User Speaker { get; set; }
    }
}
