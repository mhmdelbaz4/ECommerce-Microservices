using AutoMapper;
using Catalog.Application.Features.Requests.Queries.Brands;
using Catalog.Application.Responses.Brands;
using Catalog.Domain.Entities;
using Catalog.Application.Interfaces.Repositories;
using MediatR;

namespace Catalog.Application.Features.Handlers.Queries.Brands;
public class GetAllBrandsQueryHandler(IGenericRepository<Brand> _brandsRepo,
                                      IMapper _mapper) : IRequestHandler<GetAllBrandsQueryRequest, List<BrandResponse>>
{
    public async Task<List<BrandResponse>> Handle(GetAllBrandsQueryRequest request, CancellationToken cancellationToken)
    {
        var brands = await _brandsRepo.GetAllEntitiesAsync();
        return _mapper.Map<List<BrandResponse>>(brands);
    }
}
