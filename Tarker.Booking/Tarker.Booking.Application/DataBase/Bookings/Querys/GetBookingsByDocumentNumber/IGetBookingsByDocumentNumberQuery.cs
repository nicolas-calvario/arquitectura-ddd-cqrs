namespace Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByDocumentNumber
{
    public interface IGetBookingsByDocumentNumberQuery
    {
        Task<List<GetBookingsByDocumentNumberModel>> Execute(string documerNumber);
    }
}
