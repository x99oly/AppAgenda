using SimpleAgenda.DTOS.Internals;

namespace SimpleAgenda.Entities
{
    internal class Appointment
    {
        internal readonly int Id = Aid.AidClasses.AidIdentifier.RandomIntId(4);
        internal DateTime Date { get; private set; }
        internal Event Event {  get; private set; }

        internal Appointment(DateTime date, SimpleAgenda.Entities.Event newEvent)
        {
            Date = date;
            Event = newEvent; 
        }

        internal Appointment(DateTime date, string title, string? description = null, Location? location = null)
        {
            Date = date;
            Event = new SimpleAgenda.Entities.Event(title, description, location);
        }

        internal Appointment(AppointmentDto dto)
        {
            Id = dto.Id;
            Date = dto.Date;
            Event = new Event(dto.EventDto);
        }
    }
}
