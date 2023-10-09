using Tarker.Booking.Application.DataBase.User.Commands.UpdateUser;
using Tarker.Booking.Domian.Entities.User;

namespace Tarker.Booking.Application.DataBase.User.Commands.UpdateUserPassword
{
    public class UpdateUserPasswordCommand : IUpdateUserPasswordCommand
    {
        private readonly IDataBaseService _dataBaseService;

        public UpdateUserPasswordCommand(IDataBaseService dataBaseService)
        {
            _dataBaseService = dataBaseService;
        }
        public async Task<bool> Execute(UpdateUserPasswordModel model)
        {
            var entity = _dataBaseService.User.FirstOrDefault(x => x.UserId == model.UserId);
            if(entity == null)
            {
                return false;
            }
            
            entity.Password= model.Password;
            return await _dataBaseService.SaveAsync();
            
        }
    }
}
