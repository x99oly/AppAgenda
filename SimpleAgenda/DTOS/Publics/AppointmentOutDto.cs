using System.ComponentModel.DataAnnotations;

namespace SimpleAgenda.DTOS.Publics
{
    public class AppointmentOutDto
    {
        public DateTime Date { get; set; }
        public EventOutDto Event { get; set; } = null!;
    }
}
