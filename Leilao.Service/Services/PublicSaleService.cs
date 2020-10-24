using AutoMapper;
using Leilao.Domain.Dtos.PublicSale;
using Leilao.Domain.Entities;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Leilao.Service.Services
{
    public class PublicSaleService : IPublicSaleService
    {
        private readonly IPublicSalesRepository _repository;
        private readonly IMapper _mapper;

        public PublicSaleService(IPublicSalesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<PublicSaleDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<PublicSaleDto>(entity);
        }

        public async Task<PublicSaleDtoCreateResult> Post(PublicSaleDtoCreate publicSale)
        {
            var entity = _mapper.Map<PublicSaleEntity>(publicSale);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<PublicSaleDtoCreateResult>(result);
        }

        public async Task<PublicSaleDtoUpdateResult> Put(PublicSaleDtoUpdate publicSale)
        {
            var entity = _mapper.Map<PublicSaleEntity>(publicSale);
            var result = await _repository.InsertAsync(entity);
            return _mapper.Map<PublicSaleDtoUpdateResult>(result);
        }
    }
}
