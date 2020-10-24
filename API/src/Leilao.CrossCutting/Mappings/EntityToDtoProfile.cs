using AutoMapper;
using Leilao.Domain.Dtos.PublicSale;
using Leilao.Domain.Dtos.User;
using Leilao.Domain.Entities;

namespace Leilao.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            _mappingUser();
            _mappingPublicSale();
        }

        private void _mappingPublicSale()
        {
            CreateMap<PublicSaleDto, PublicSaleEntity>().ReverseMap();
            CreateMap<PublicSaleDtoCreateResult, PublicSaleEntity>().ReverseMap();
            CreateMap<PublicSaleDtoUpdateResult, PublicSaleEntity>().ReverseMap();
        }

        private void _mappingUser()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
        }
    }
}
