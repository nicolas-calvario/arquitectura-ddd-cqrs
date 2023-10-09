﻿using AutoMapper;
using Tarker.Booking.Domian.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.CreateUser
{
    public class CreateUserCommand:ICreateUserCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public CreateUserCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task <CreateUserModel> Execute(CreateUserModel model)
        {
            var entity =_mapper.Map<UserEntity>(model);
            await _dataBaseService.User.AddAsync(entity);
            await _dataBaseService.SaveAsync();
            return model;
        }
    }
}
