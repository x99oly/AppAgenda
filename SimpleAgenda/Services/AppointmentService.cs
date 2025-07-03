using SimpleAgenda.Entities;
using SimpleAgenda.Context;
using SimpleAgenda.Interfaces;
using SimpleAgenda.Repositories;
using SimpleAgenda.DTOS.Internals;
using SimpleAgenda.DTOS.Publics;
using System.Runtime.CompilerServices;

namespace SimpleAgenda.Services
{
    public class AppointmentService<T> where T : AppointmentOutDto
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
            T? result = await PrivateGet(id);

            if (result == null)
                return new AppointmentOutDto();

            return result;
        }

        private async Task<T?> PrivateGet(int id) => await _repository.Get(id) ?? null;

        public async Task<List<AppointmentOutDto>> GetList()
        {
            List<T> results = await _repository.GetList();

            return results
                .Select(item =>
                {
                    return item as AppointmentOutDto;
                })
                .ToList();
        }

        public async Task<int> Create(T entity)
        {

            AppointmentOutDto apot = entity as AppointmentOutDto
            ?? throw new InvalidCastException($"The type passed does not match the signature of 'AppointmentOutDto'.");

            DateTime date = apot.Date ?? throw new ArgumentNullException(nameof(apot.Date), $"The parameter 'Date' cannot be null.");

            AppointmentOutDto ap = new Appointment(date, new Event(apot.Event)).ConvertToPublicDto();

            T? apt = ap as T;
            if (apt is null) return 0;

            await _repository.Create(apt);

            return ap.Id;
        }

        public async Task Update(int id, AppointmentOutDto entity)
        {
            T? recoverEntity = await PrivateGet(id);

            if (recoverEntity == null)
                throw new KeyNotFoundException($"Entity with ID {id} not found.");

            Appointment? ap = ConvertToAppointment(recoverEntity);

            if (ap == null)
                throw new InvalidCastException("The entity cannot be converted to an Appointment.");

            // Update the appointment with the new data
            ap.Update(entity);

            object internalDto = ap.ConvertToInternalDto();

            if (internalDto is not T dto)
                throw new InvalidCastException($"Esperava tipo {typeof(T).Name}, mas recebi {internalDto.GetType().Name}");

            await _repository.Update(dto);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        private AppointmentOutDto? ConvertToAppointmentOutDto(T result)
        {
            Appointment? ap = ConvertToAppointment(result);
            if (ap == null)
                return null;

            return ap.ConvertToPublicDto();
        }

        private Appointment? ConvertToAppointment(T result)
        {
            AppointmentDto? ap = ConvertToAppointmentDto(result);
            if (ap == null)
                return null;

            return new Appointment(ap);
        }

        private AppointmentDto? ConvertToAppointmentDto(T result)
        {
            return result as AppointmentDto ?? null;
        }

    }
}
