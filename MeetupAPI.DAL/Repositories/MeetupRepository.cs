using MeetupAPI.DAL.Interfaces;
using MeetupAPI.Domain.Entity;

namespace MeetupAPI.DAL.Repositories
{
    public class MeetupRepository : IBaseRepository<Meetup>
    {
        private readonly ApplicationDbContext _db;
        public MeetupRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Meetup entity)
        {
            await _db.Meetups.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Meetup entity)
        {
            _db.Meetups.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Meetup> GetAll()
        {
            return _db.Meetups;
        }

        public async Task<Meetup> Update(Meetup entity)
        {
            _db.Meetups.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
