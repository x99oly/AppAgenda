using SimpleAgenda.DTOS.Internals;

namespace SimpleAgenda.Entities
{
    internal class Event
    {
        internal readonly int id = Aid.AidClasses.AidIdentifier.RandomIntId(4);

        internal string Title { get; set; }

        internal string Description { get; set; }

        internal Location? Location { get; set; }

        internal Event(string title, string? description = null, Location? location = null)
        {
            Title = title;
            Description = description ?? string.Empty;
            Location = location;
        }

        internal Event(EventDto dto)
        {
            id = dto.Id;
            Title = dto.Title;
            Description = dto.Description ?? string.Empty;
            Location = dto.Location != null ? new Location(dto.Location) : null;
        }


    }
}
