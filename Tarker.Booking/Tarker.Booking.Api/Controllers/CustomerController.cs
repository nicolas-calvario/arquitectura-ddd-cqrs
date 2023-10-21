using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tarker.Booking.Application.DataBase.Customer.Commands.CreateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer;
using Tarker.Booking.Application.DataBase.Customer.Commands.UpdateCustomer;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetAllCustomers;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByID;
using Tarker.Booking.Application.DataBase.Customer.Querys.GetCustomerByNumberDocument;
using Tarker.Booking.Application.Exceptions;
using Tarker.Booking.Application.Features;

namespace Tarker.Booking.Api.Controllers
{
    [Route("api/v1/customer")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class CustomerController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateCustomerModel model, [FromServices] ICreateCustomerCommand createCustomerCommand, [FromServices] IValidator<CreateCustomerModel> validator)
        {
            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await createCustomerCommand.Execute(model);
            return StatusCode(StatusCodes.Status201Created, ResponseApiService.Response(StatusCodes.Status201Created, data));
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> GetAll([FromServices] IGetAllCustomersQuery getAllCustomersQuery)
        {
            var data = await getAllCustomersQuery.Execute();

            if (data.Count == 0)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id, [FromServices] IGetCustomerByIdCommand getCustomerByIdCommand)
        {
            var data = await getCustomerByIdCommand.Execute(id);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpPut("update-customer")]
        public async Task<ActionResult> Update([FromBody] UpdateCustomerModel model, [FromServices] IUpdateCustomerCommand updateCustomerCommand, [FromServices] IValidator<UpdateCustomerModel> validator)
        {

            var validate = await validator.ValidateAsync(model);

            if (!validate.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ResponseApiService.Response(StatusCodes.Status400BadRequest, validate.Errors));

            var data = await updateCustomerCommand.Execute(model);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id, [FromServices] IDeleteCustomerCommand deleteCustomerCommand)
        {
            var data = await deleteCustomerCommand.Execute(id);

            if (!data)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }

        [HttpGet("get-by-number-document/{numberDocument}")]
        public async Task<ActionResult> GetByCustomerByNumberDocument(string numberDocument, [FromServices] IGetCustomerByNumberDocument getCustomerByNumberDocument)
        {
            var data = await getCustomerByNumberDocument.Execute(numberDocument);

            if (data == null)
                return StatusCode(StatusCodes.Status404NotFound, ResponseApiService.Response(StatusCodes.Status404NotFound, data));

            return StatusCode(StatusCodes.Status200OK, ResponseApiService.Response(StatusCodes.Status200OK, data));
        }
    }
}
