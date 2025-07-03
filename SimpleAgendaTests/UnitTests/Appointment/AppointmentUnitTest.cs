using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleAgenda.DTOS.Publics;
using SimpleAgenda.Services;
using Xunit;

namespace SimpleAgendaTests.UnitTests.Appointment
{
    public class AppointmentServicePublicDtoTests
    {
        private readonly AppointmentService<AppointmentOutDto> _service;

        public AppointmentServicePublicDtoTests()
        {            
            var repository = new InMemoryRepository<AppointmentOutDto>();
            _service = new AppointmentService<AppointmentOutDto>(repository);
        }

        [Fact]
        public async Task Create_ValidAppointment_ReturnsCreatedId()
        {
            var newAppointment = new AppointmentOutDto
            {
                Date = DateTime.Today.AddDays(2),
                Event = new EventOutDto { Title = "Evento Público 3" }
            };
            int createdId = await _service.Create(newAppointment);
            Assert.True(createdId > 0);
        }

        [Fact]
        public async Task Create_NullAppointment_ThrowsInvalidCastException()
        {
            await Assert.ThrowsAsync<InvalidCastException>(() => _service.Create(null!));
        }

        [Fact]
        public async Task Create_NullEvent_ThrowsNullReferenceException()
        {
            await Assert.ThrowsAsync<NullReferenceException>(() => _service.Create(
                new AppointmentOutDto
                {
                    Id = 1234,
                    Date = DateTime.Today.AddDays(2),
                    Event = null!
                }
                ));
        }

        [Fact]
        public async Task Create_NullDate_ThrowsArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _service.Create(
                    new AppointmentOutDto
                    {
                        Id = 1234,
                        Date = null!,
                        Event = new EventOutDto
                        {
                            Title = "Evento público 4."
                        }
                    }
                ));
        }

        [Fact]
        public async Task Get_Returns_Correct_AppointmentOutDto()
        {
            string title = "Random Event 0";
            DateTime eventDate = DateTime.Today.AddDays(2);

            var newAppointment = new AppointmentOutDto
            {
                Date = eventDate,
                Event = new EventOutDto { Title = title }
            };
            int createdId = await _service.Create(newAppointment);

            var result = await _service.Get(createdId); // Ajuste se tiver Id, veja abaixo

            Assert.NotNull(result);
            Assert.Equal(title, result.Event.Title);
            Assert.Equal(eventDate, result.Date);
        }

        [Fact]
        public async Task GetList_Returns_All_AppointmentOutDtos()
        {
            string t0 = string.Empty, t1 = string.Empty;
            
            t0 = "List Event 0";
            DateTime eventDate = DateTime.Today.AddDays(2);

            var newAppointment = new AppointmentOutDto
            {
                Date = eventDate,
                Event = new EventOutDto { Title = t0 }
            };
            int createdId = await _service.Create(newAppointment);

            t1 = "List Event 1";
            eventDate = DateTime.Today.AddDays(2);

            newAppointment = new AppointmentOutDto
            {
                Date = eventDate,
                Event = new EventOutDto { Title = t1 }
            };
            createdId = await _service.Create(newAppointment);


            var list = await _service.GetList();

            Assert.True(list.Count >= 2);
            Assert.Contains(list, dto => dto.Event.Title == t0);
            Assert.Contains(list, dto => dto.Event.Title == t1);
        }

    }
}
