using Duckendar.Model.Interfaces;
using SQLite;

namespace Duckendar.Model.Entities.DTOs
{
    public class AppointmentDto
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string? DayOfWeek { get; set; }

        public int Time { get; set; }
    }
}
