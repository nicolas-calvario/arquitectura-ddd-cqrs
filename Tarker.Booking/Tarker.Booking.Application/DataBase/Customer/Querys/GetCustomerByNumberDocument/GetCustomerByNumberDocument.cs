using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByNumberDocument
{
    public class GetCustomerByNumberDocument:IGetCustomerByNumberDocument
    {
        private readonly IDataBaseService _dataBaseService;
        private readonly IMapper _mapper;

        public GetCustomerByNumberDocument(IDataBaseService dataBaseService, IMapper mapper)
        {
            _dataBaseService = dataBaseService;
            _mapper = mapper;
        }

        public async Task<GetCustomerByNumberDocumentModel> Execute(string numberDocument)
        {
            var entity = await _dataBaseService.Customer.Where(x => x.DocumentNumber == numberDocument).FirstOrDefaultAsync();
            return _mapper.Map<GetCustomerByNumberDocumentModel>(entity);
        }
    }
}
