using AutoMapper;
using Leilao.Domain.Dtos.PublicSale;
using Leilao.Domain.Dtos.PublicSale.Standard;
using Leilao.Domain.Dtos.Validation;
using Leilao.Domain.Entities;
using Leilao.Domain.Interfaces.Repositories;
using Leilao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leilao.Service.Services
{
    public class PublicSaleService : IPublicSaleService
    {
        private readonly IPublicSalesRepository _repository;
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public PublicSaleService(IPublicSalesRepository repository, IMapper mapper, IUsersRepository usersRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _usersRepository = usersRepository;
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

        public async Task<IEnumerable<PublicSaleDto>> Get()
        {
            var listEntity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<PublicSaleDto>>(listEntity);
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
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<PublicSaleDtoUpdateResult>(result);
        }

        public async Task<DtoValidation> Validation(PublicSaleDtoStandardValidation publicSale)
        {
            return await Validation(publicSale, Guid.NewGuid());
        }

        public async Task<DtoValidation> Validation(PublicSaleDtoStandardValidation publicSale, Guid Id)
        {
            var validation = new DtoValidation() { Sucess = true };
            var entityUser = await _usersRepository.SelectAsync(publicSale.ResponsibleUserId);
            if (entityUser == null)
            {
                validation.Sucess = false;
                validation.Message = "Usuario não encontrado.";
                return validation;
            }

            var lstentity = await _repository.SelectAsync(ps => 
                ps.Name.Trim().ToLower().Equals(publicSale.Name.Trim().ToLower()) &&
                ps.ResponsibleUserId == publicSale.ResponsibleUserId);
            var entity = lstentity.FirstOrDefault();

            if (entity != null && !entity.Id.Equals(Id))
            {
                validation.Sucess = false;
                validation.Message = "Item ja cadastrado.";
                return validation;
            }

            return validation;
        }
    }
}
