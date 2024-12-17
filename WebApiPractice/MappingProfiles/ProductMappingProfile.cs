using AutoMapper;
using WebApiPractice.Models;

namespace WebApiPractice.MappingProfiles;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<ProductCreateDto, Product>();
    }
}
