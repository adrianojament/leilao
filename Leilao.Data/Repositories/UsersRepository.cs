using Leilao.Data.Context;
using Leilao.Data.Repositories.Standard;
using Leilao.Domain.Entities;
using Leilao.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Data.Repositories
{
    public class UsersRepository : Repository<UserEntity>, IUsersRepository
    {
        public UsersRepository(PublicSaleContext context, DbSet<UserEntity> dataSet) : base(context, dataSet)
        {
        }
    }
}
