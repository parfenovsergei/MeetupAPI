using MeetupAPI.DAL.Interfaces;
using MeetupAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.BLL.Services.MeetupService
{
    public class MeetupService : IMeetupService
    {
        private readonly IBaseRepository<Meetup> _meetupRepository;
        private readonly IBaseRepository<User> _userRepository;
        public MeetupService(IBaseRepository<Meetup> meetuprepository, IBaseRepository<User> userRepository)
        {
            _meetupRepository = meetuprepository;
            _userRepository = userRepository;
        }

        public async Task<string> AddMeetup(Meetup meetup, string speakerEmail, string organizerEmail)
        {
            try
            {
                var organizer = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == organizerEmail);
                var speaker = await _userRepository.GetAll().FirstOrDefaultAsync(u => u.Email == speakerEmail);

                Meetup newMeetup = new Meetup
                {
                    MeetupName = meetup.MeetupName,
                    Description = meetup.Description,
                    MeetupDate = meetup.MeetupDate,
                    MeetupLocation = meetup.MeetupLocation,
                    Speaker = speaker,
                    Organizer = organizer
                };

                await _meetupRepository.Create(newMeetup);

                return "Событие добавлено успешно.";
            }
            catch(Exception)
            {
                return "Ошибка добавления.";
            }
        }

        public async Task<List<Meetup>> GetAll()
        {
            try
            {
                var meetups = await _meetupRepository.GetAll().ToListAsync();
                return meetups;
            }
            catch(Exception)
            {
                throw new Exception("Ошибка получения данных.");
            }
        }

        public async Task<Meetup> GetMeetup(int id)
        {
            try
            {
                var meetup = await _meetupRepository.GetAll().FirstOrDefaultAsync(m => m.MeetupId == id);
                return meetup;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка получения данных.");
            }
        }
    }
}
