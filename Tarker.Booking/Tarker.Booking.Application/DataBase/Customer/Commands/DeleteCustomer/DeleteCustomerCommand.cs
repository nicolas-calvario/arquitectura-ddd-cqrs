namespace Tarker.Booking.Application.DataBase.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand: IDeleteCustomerCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteCustomerCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> Execute(int CustomerId)
        {
            var entity = _dataBaseService.Customer.FirstOrDefault(x => x.CustomerId == CustomerId);
            if (entity == null)
            {
                return false;
            }

            _dataBaseService.Customer.Remove(entity);
            return await _dataBaseService.SaveAsync();

        }
    }
}