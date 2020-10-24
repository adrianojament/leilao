using Leilao.Domain.Dtos.User;
using System;
using System.Threading.Tasks;

namespace Leilao.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);
    }
}
