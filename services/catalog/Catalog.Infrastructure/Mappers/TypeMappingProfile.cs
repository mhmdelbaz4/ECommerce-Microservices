using AutoMapper;
using Catalog.Application.Responses.Types;
using Catalog.Infrastructure.Documents;

namespace Catalog.Infrastructure.Mappers;
public class TypeMappingProfile : Profile
{
    public TypeMappingProfile()
    {
        CreateMap<Domain.Entities.Type, TypeDocument>().ReverseMap();
        CreateMap<Domain.Entities.Type, TypeResponse>().ReverseMap();
    }
}
