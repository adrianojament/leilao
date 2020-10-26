using Leilao.Domain.Dtos.User;
using Leilao.Domain.Dtos.User.Standard;
using Leilao.Domain.Dtos.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leilao.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> Get();
        Task<UserDto> Get(Guid id);        
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);
        Task<DtoValidation> Validation(UserDtoValidation user);
        Task<DtoValidation> Validation(UserDtoValidation user, Guid id);
    }
}
