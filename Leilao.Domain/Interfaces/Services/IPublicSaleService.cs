using Leilao.Domain.Dtos.PublicSale;
using System;
using System.Threading.Tasks;

namespace Leilao.Domain.Interfaces.Services
{
    public interface IPublicSaleService
    {
        Task<PublicSaleDto> Get(Guid id);
        Task<PublicSaleDtoCreateResult> Post(PublicSaleDtoCreate publicSale);
        Task<PublicSaleDtoUpdateResult> Put(PublicSaleDtoUpdate publicSale);
        Task<bool> Delete(Guid id);
    }
}
