using AutoMapper;
using MeetupAPI.BLL.Services.MeetupService;
using MeetupAPI.Domain.Entity;
using MeetupAPI.ViewModels.MeetupViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetupAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        private readonly IMeetupService _meetupService;
        public MeetupController(IMeetupService meetupService)
        {
            _meetupService = meetupService;
        }

        [HttpGet("GetAllMeetups")]
        [Authorize]
        public async Task<List<ReadMeetupViewModel>> GetMeetups()
        {
            var meetups = await _meetupService.GetAll();
            if (meetups != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Meetup, ReadMeetupViewModel>()
                    .ForMember("OrganizerEmail", opt => opt.MapFrom(c => c.Organizer.Email))
                    .ForMember("SpeakerEmail", opt => opt.MapFrom(c => c.Speaker.Email)));
                var mapper = new Mapper(config);

                List<ReadMeetupViewModel> readMeetups = mapper.Map<List<Meetup>, List<ReadMeetupViewModel>>(meetups);
                return readMeetups;
            }
            else
                throw new ArgumentNullException("Meetups are not exists.");
        }

        [HttpGet("GetMeetup/{id}")]
        [Authorize]
        public async Task<ReadMeetupViewModel> GetMeetup(int id)
        {
            var meetup = await _meetupService.GetMeetup(id);
            if (meetup != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Meetup, ReadMeetupViewModel>()
                    .ForMember("OrganizerEmail", opt => opt.MapFrom(c => c.Organizer.Email))
                    .ForMember("SpeakerEmail", opt => opt.MapFrom(c => c.Speaker.Email)));
                var mapper = new Mapper(config);

                ReadMeetupViewModel readMeetup = mapper.Map<Meetup, ReadMeetupViewModel>(meetup);
                return readMeetup;
            }
            else
                throw new ArgumentNullException("Meetup is not exists.");
        }

        [HttpPost("AddMeetup")]
        [Authorize]
        public async Task<string> AddMeetup(CreateMeetupViewModel request)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CreateMeetupViewModel, Meetup>()
                .ForMember("MeetupName", opt => opt.MapFrom(c => c.MeetupName))
                .ForMember("Description", opt => opt.MapFrom(c => c.Description))
                .ForMember("MeetupDate", opt => opt.MapFrom(c => c.MeetupDate))
                .ForMember("MeetupLocation", opt => opt.MapFrom(c => c.MeetupLocation)));
            var mapper = new Mapper(config);

            Meetup meetup = mapper.Map<CreateMeetupViewModel, Meetup>(request);

            return await _meetupService.AddMeetup(meetup, request.SpeakerEmail, HttpContext.User.Identity.Name);
        }

        [HttpPut("UpdateMeetup/{id}")]
        public async Task<ReadMeetupViewModel> UpdateMeetup(int id, UpdateMeetupViewModel request)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UpdateMeetupViewModel, Meetup>()
                .ForMember("MeetupName", opt => opt.MapFrom(c => c.MeetupName))
                .ForMember("Description", opt => opt.MapFrom(c => c.Description))
                .ForMember("MeetupDate", opt => opt.MapFrom(c => c.MeetupDate))
                .ForMember("MeetupLocation", opt => opt.MapFrom(c => c.MeetupLocation)));
            var mapper = new Mapper(config);
            Meetup meetup = mapper.Map<UpdateMeetupViewModel, Meetup>(request);

            var updatedMeetup = await _meetupService.UpdateMeetup(id, meetup, request.SpeakerEmail);

            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<Meetup, ReadMeetupViewModel>()
                .ForMember("OrganizerEmail", opt => opt.MapFrom(c => c.Organizer.Email))
                .ForMember("SpeakerEmail", opt => opt.MapFrom(c => c.Speaker.Email)));
            var mapper2 = new Mapper(config2);
            ReadMeetupViewModel readMeetup = mapper2.Map<Meetup, ReadMeetupViewModel>(updatedMeetup);

            return readMeetup;
        }

        [HttpDelete("DeleteMeetup/{id}")]
        public async Task<string> DeleteMeetup(int id)
        {
            var response = await _meetupService.DeleteMeetup(id);
            return response;
        }
    }
}
