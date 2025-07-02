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
            Appointment appointment = new Appointment((AppointmentDto)await _repository.Get(id));
            return new AppointmentOutDto(appointment);
        }

        public async Task<List<T>> GetList()
        {
            return await _repository.GetList();
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
    }
}
