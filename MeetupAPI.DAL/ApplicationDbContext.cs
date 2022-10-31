using MeetupAPI.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupAPI.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Meetup> Meetups { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meetup>()
                .HasOne(u => u.Organizer)
                .WithMany(m => m.OrganizedMeetups)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasForeignKey(u => u.OrganizerId);
            modelBuilder.Entity<Meetup>()
                .HasOne(u => u.Speaker)
                .WithMany(m => m.SpeakerMeetups)
                .OnDelete(DeleteBehavior.ClientNoAction)
                .HasForeignKey(u => u.SpeakerId);
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FirstName = "AdminFirstName",
                LastName = "AdminLastName",
                Email = "adminMeetupApi@mail.ru",
                Password = "bf1694a8d7ae9c823d0ae9f2380ce4ec094c0f6b0d8db6b311deb7d1704aec94",
                Role = "Admin"
            });
        }
    }
}
