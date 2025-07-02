using Duckendar.Aid.AidClasses;
using Duckendar.Model.Entities.DTOs;

namespace Duckendar.Model.Entities.ComposeEntities
{
    public class Appointment(DayOfWeek day, TimeOnly time)
    {
        public int Id { get; private set; } = AidIdentifier.RandomIntId(4); 
        public DayOfWeek DayOfWeek { get; set; } = day;
        public TimeOnly TimeOnly { get; set; } = time;
    }
}
