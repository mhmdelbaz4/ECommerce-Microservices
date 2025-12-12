using AutoMapper;
using Catalog.Application.Responses.Brands;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Documents;

namespace Catalog.Infrastructure.Mappers;
public class BrandMappingProfile : Profile
{
    public BrandMappingProfile()
    {
        CreateMap<Brand,BrandDocument>().ReverseMap();
        CreateMap<Brand,BrandResponse>().ReverseMap();
    }
}
