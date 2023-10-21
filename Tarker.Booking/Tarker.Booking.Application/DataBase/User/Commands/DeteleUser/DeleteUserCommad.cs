namespace Tarker.Booking.Application.DataBase.User.Commands.DeteleUser
{
    public class DeleteUserCommad : IDeleteUserCommad
    {
        private readonly IDataBaseService _dataBaseService;

        public DeleteUserCommad(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> Execute(int userId)
        {
            var entity = _dataBaseService.User.FirstOrDefault(x => x.UserId == userId);
            if (entity == null)
            {
                return false;
            }

            _dataBaseService.User.Remove(entity);
            return await _dataBaseService.SaveAsync();

        }
    }
}