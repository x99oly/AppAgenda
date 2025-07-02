using SimpleAgenda.Entities;
using SimpleAgenda.Context;
using SimpleAgenda.Interfaces;
using SimpleAgenda.Repositories;
using SimpleAgenda.DTOS.Internals;
using SimpleAgenda.DTOS.Publics;

namespace SimpleAgenda.Services
{
    public class AppointmentService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public AppointmentService()
        {
            _repository = new AgendaRepository<T>(new SqliteContext());
        }

        public AppointmentService(IRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<AppointmentOutDto?> Get(int id)
        {
            T? result = await _repository.Get(id);
            if (result == null)
                return new AppointmentOutDto();

            return ConvertToAppointmentoutDto(result);
        }

        public async Task<List<AppointmentOutDto>> GetList()
        {
            List<T> results = await _repository.GetList();

            return results
                .Select(item =>
                {
                    return ConvertToAppointmentoutDto(item);
                })
                .ToList();
        }

        public async Task Create(T entity)
        {
            await _repository.Create(entity);
        }

        public async Task Update(T entity)
        {
            await _repository.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }


        private AppointmentOutDto ConvertToAppointmentoutDto(T result)
        {
            AppointmentDto? appointmentDto = result as AppointmentDto
            ?? throw new InvalidCastException($"The entity of type {typeof(T).Name} cannot be cast to AppointmentDto.");

            Appointment appointment = new Appointment(appointmentDto);
            return appointment.ConvertToPublicDto();
        }

    }
}
