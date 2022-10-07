using AutoMapper;
using CleanArch.Application.Dtos;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : BaseService<Product, ProductDto>, IProductService
    {
        public ProductService(IBaseRepository<Product> repository, IMapper mapper)
            : base(repository, mapper)
        { }
    }
}
