using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.User.Querys.GetUserByUserNameAndPasswordQuery
{
    public class GetUserByUserNameAndPasswordQuery: IGetUserByUserNameAndPasswordQuery
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetUserByUserNameAndPasswordQuery(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetUserByUserNameAndPasswordQueryModel> Execute(string userName,string password)
        {
            var entity = await _dataBaseService.User.FirstOrDefaultAsync( x => x.UserName== userName && x.Password == password);
            return _mapper.Map<GetUserByUserNameAndPasswordQueryModel>(entity);
        }
    }
}
