using AutoMapper;
using Leilao.Domain.Dtos.PublicSale;
using Leilao.Domain.Dtos.User;
using Leilao.Domain.Entities;

namespace Leilao.CrossCutting.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            _mappingUser();
            _mappingPublicSale();
        }

        private void _mappingPublicSale()
        {
            CreateMap<PublicSaleEntity, PublicSaleDto>().ReverseMap();
            CreateMap<PublicSaleEntity, PublicSaleDtoCreate>().ReverseMap();
            CreateMap<PublicSaleEntity, PublicSaleDtoUpdate>().ReverseMap();
        }

        private void _mappingUser()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserEntity, UserDtoCreate>().ReverseMap();
            CreateMap<UserEntity, UserDtoUpdate>().ReverseMap();
        }
    }
}
