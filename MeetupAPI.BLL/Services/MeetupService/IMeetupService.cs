using MeetupAPI.Domain.Entity;

namespace MeetupAPI.BLL.Services.MeetupService
{
    public interface IMeetupService
    {
        Task<List<Meetup>> GetAll();
        Task<string> AddMeetup(Meetup meetup, string speakerEmail, string organizerEmail);
        Task<Meetup> GetMeetup(int id);
        Task<Meetup> UpdateMeetup(int id, Meetup updatedMeetup, string newSpeaker);
        Task<string> DeleteMeetup(int id);
    }
}
