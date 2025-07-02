using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duckendar.Model.Entities.DTOs
{
    public class SchedulingDto
    {
        [PrimaryKey]
        public int Id { get; set; }

        public int TraineeId { get; set; }  // FK para TraineeDto

        public long CreatedAt { get; set; }

        public List<AppointmentDto> SchedulingDays { get; set; } = new();

        public bool IsToRepeat { get; set; }

        public string? Observations { get; set; }
    }
}
