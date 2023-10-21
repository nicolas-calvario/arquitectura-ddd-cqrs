using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByID
{
    public class GetCustomerByIdCommand :IGetCustomerByIdCommand
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByIdCommand(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }
        public async Task<GetCustomerByIdModel> Execute(int id)
        {
            var entity = await _dataBaseService.Customer.Where(x => x.CustomerId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetCustomerByIdModel>(entity);
        } 
    }
}
