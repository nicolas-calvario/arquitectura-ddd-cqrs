﻿using AutoMapper;
using Tarker.Booking.Domian.Entities.Booking;

namespace Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : ICreateBookingCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateBookingCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<CreateBookingModel> Execute(CreateBookingModel createBookingModel)
        {
            var entity = _mapper.Map<BookingEntity>(createBookingModel);
            await _dataBaseService.Booking.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return createBookingModel;
        }
    }
}
