using Duckendar.Aid.AidClasses;
using Duckendar.Model.Entities.ComposeEntities;
using Duckendar.Model.Interfaces;
using Duckendar.Model.Entities.DTOs;

namespace Duckendar.Model.Entities.MainEntities
{
    public class Scheduling : IDtoConvertable<SchedulingDto>
    {
        public readonly int Id = AidIdentifier.RandomIntId(5);
        public readonly Trainee Trainee;
        public readonly long CreatedAt = DateTimeOffset.UtcNow.ToUnixTimeSeconds(); // UnixTimestamp

        public List<Appointment> SchedulingDays;
        public bool IsToRepeat { get; private set; } 
        public string? Observations { get; private set; }

        /// <summary>
        /// The value of the observations and isToRepeat, must be passed using named argument syntax.
        /// </summary>
        /// <param name="trainee">The pupil entitie.</param>
        /// <param name="days">The list of the training days of the pupil.</param>
        /// <param name="observations">Details of the pupil.</param>
        /// <param name="isToRepeat">Training recurrence status.</param>
        public Scheduling(Trainee trainee, List<Appointment> days, string? observations = null, bool isToRepeat = true)
        {
            Trainee = trainee;
            SchedulingDays = days ?? new List<Appointment>();
            Observations = observations;
            IsToRepeat = isToRepeat;
        }

        public SchedulingDto ToDto()
        {
            SchedulingDto dto = new();
            dto.Id = Id;
            dto.TraineeId = Trainee.Id;
            dto.CreatedAt = CreatedAt;
            dto.Observations = Observations;
            return dto;
        }
    }
}
