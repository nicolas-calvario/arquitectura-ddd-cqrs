using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tarker.Booking.Application.DataBase.Bookings.Commands.CreateBooking;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetAllBookings;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByDocumentNumber;
using Tarker.Booking.Application.DataBase.Bookings.Querys.GetBookingsByType;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class BookingController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateBookingModel model, [FromServices] ICreateBookingCommand createBookingCommand, [FromServices] IValidator<CreateBookingModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

        var data = await createBookingCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll([FromServices] IGetAllBookingsQuery getAllBookingsQuery)
        {
            var data = await getAllBookingsQuery.Execute();

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-number-document")]
        public async Task<ActionResult> GetByBookingByNumberDocument([FromQuery]string numberDocument, [FromServices] IGetBookingsByDocumentNumberQuery getBookingsByDocumentNumberQuery)
        {
            if (string.IsNullOrEmpty(numberDocument))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null));

            var data = await getBookingsByDocumentNumberQuery.Execute(numberDocument);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-type")]
        public async Task<ActionResult> GetBookingByType([FromQuery]string type, [FromServices] IGetBookingsByTypeQuery getBookingsByTypeQuery)
        {
            if (string.IsNullOrEmpty(type))
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, null));

            var data = await getBookingsByTypeQuery.Execute(type);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
