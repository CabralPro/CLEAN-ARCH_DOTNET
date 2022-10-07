using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
