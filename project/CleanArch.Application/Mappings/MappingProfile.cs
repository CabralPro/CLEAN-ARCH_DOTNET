using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<BankAccount, BankAccountDto>().ReverseMap();
        }
    }
}
