using Leilao.Domain.Dtos.PublicSale;
using Leilao.Domain.Dtos.PublicSale.Standard;
using Leilao.Domain.Dtos.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leilao.Domain.Interfaces.Services
{
    public interface IPublicSaleService
    {
        Task<IEnumerable<PublicSaleDto>> Get();
        Task<PublicSaleDto> Get(Guid id);
        Task<PublicSaleDtoCreateResult> Post(PublicSaleDtoCreate publicSale);
        Task<PublicSaleDtoUpdateResult> Put(PublicSaleDtoUpdate publicSale);
        Task<bool> Delete(Guid id);
        Task<DtoValidation> Validation(PublicSaleDtoStandardValidation publicSale);
        Task<DtoValidation> Validation(PublicSaleDtoStandardValidation publicSale, Guid Id);
    }
}
