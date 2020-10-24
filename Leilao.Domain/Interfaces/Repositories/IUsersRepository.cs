using Leilao.Domain.Entities;
using Leilao.Domain.Interfaces.Repositories.Standard;

namespace Leilao.Domain.Interfaces.Repositories
{
    public interface IUsersRepository : IRepository<UserEntity>
    {
    }
}
