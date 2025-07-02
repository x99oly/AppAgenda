using Microsoft.EntityFrameworkCore;
using SimpleAgenda.DTOS.Internals;

namespace SimpleAgenda.Context
{
    internal class SqliteContext : DbContext
    {
        internal DbSet<EventDto> Events { get; set; }  // DbSet para EventDto
        internal DbSet<AppointmentDto> Appointments { get; set; }  // DbSet para AppointmentDto
        internal DbSet<LocationDto> Locations { get; set; }  // DbSet para LocationDto

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=agenda.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationDto>()
                .HasKey(l => new { l.Street, l.Number, l.City, l.PostalCode, l.Country, l.State, l.Complement });

            modelBuilder.Entity<AppointmentDto>()
                .HasOne(a => a.Event)
                .WithOne()
                .IsRequired();

            modelBuilder.Entity<EventDto>()
                .HasOne(e => e.Location)
                .WithOne()
                .IsRequired(false);
        }

    }
}
