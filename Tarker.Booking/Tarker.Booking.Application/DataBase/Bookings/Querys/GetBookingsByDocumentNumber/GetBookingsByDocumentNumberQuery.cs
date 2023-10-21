using Microsoft.EntityFrameworkCore;

namespace Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByDocumentNumber
{
    public class GetBookingsByDocumentNumberQuery : IGetBookingsByDocumentNumberQuery
    {
        private readonly IDataBaseService _dataBaseService;

        public GetBookingsByDocumentNumberQuery(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }

        public async Task<List<GetBookingsByDocumentNumberModel>>Execute(string documerNumber)
        {
            var resul = await (from booking in _dataBaseService.Booking
                               join customer in _dataBaseService.Customer
                               on booking.CustomerId equals customer.CustomerId
                               where customer.DocumentNumber == documerNumber
                               select new GetBookingsByDocumentNumberModel
                               {
                                   Code = booking.Code,
                                   RegisterDate= booking.RegisterDate,
                                   Type = booking.Type,
                               }).ToListAsync();
            return resul;
        }
    }
}
