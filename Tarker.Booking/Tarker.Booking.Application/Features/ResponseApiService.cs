using Tarker.Booking.Domian.Models;

namespace Tarker.Booking.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResposeModel Response( int statusCode, object data = null, string message = null)
        {
            bool succes = false;
            if(statusCode >= 200 &&  statusCode <300) { succes = true; }

            var result = new BaseResposeModel
            {
                StatusCode= statusCode,
                Data= data,
                Message= message,
                Success = succes
            };
            return result;
        }
    }
}
