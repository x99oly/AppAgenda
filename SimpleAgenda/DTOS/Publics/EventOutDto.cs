using System.ComponentModel.DataAnnotations;

namespace SimpleAgenda.DTOS.Publics
{
    public class EventOutDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public LocationOutDto? Location { get; set; }
    }
}
