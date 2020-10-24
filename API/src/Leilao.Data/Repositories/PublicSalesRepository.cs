using Leilao.Data.Context;
using Leilao.Data.Repositories.Standard;
using Leilao.Domain.Entities;
using Leilao.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Leilao.Data.Repositories
{
    public class PublicSalesRepository : Repository<PublicSaleEntity>, IPublicSalesRepository
    {
        public PublicSalesRepository(PublicSaleContext context) : base(context)
        {
            _dataset = _context.Set<PublicSaleEntity>();
        }
    }
}
