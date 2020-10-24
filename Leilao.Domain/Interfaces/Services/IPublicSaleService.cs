using Leilao.Domain.Dtos.PublicSale;
using Leilao.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Leilao.Domain.Interfaces.Services
{
    public interface IPublicSaleService
    {
        Task<PublicSaleDto> Get(Guid id);        
        Task<PublicSaleDtoCreateResult> Post(PublicSaleDtoCreate cep);
        Task<PublicSaleDtoUpdateResult> Put(PublicSaleDtoUpdate cep);
        Task<bool> Delete(Guid id);
    }
}
