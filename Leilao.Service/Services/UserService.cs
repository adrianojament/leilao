using AutoMapper;
using Leilao.Domain.Dtos.User;
using Leilao.Domain.Entities;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Leilao.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUsersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDtoCreateResult> Post(UserDtoCreate user)
        {
            var entity = _mapper.Map<UserEntity>(user);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDtoUpdate user)
        {
            var entity = _mapper.Map<UserEntity>(user);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
