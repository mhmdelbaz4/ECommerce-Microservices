using AutoMapper;
using Catalog.Application.Features.Requests.Queries.Products;
using Catalog.Application.Responses.Products;
using Catalog.Domain.Entities;
using Catalog.Application.Interfaces.Repositories;
using MediatR;
using Catalog.Application.Responses;

namespace Catalog.Application.Features.Handlers.Queries.Products;
public class GetAllProductsQueryHandler(IMapper _mapper,
                                        IProductRepository _productsRepository)
                                      :IRequestHandler<GetAllProductsQueryRequest, PaginationReponse<ProductResponse>>
{
    public async Task<PaginationReponse<ProductResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
    {
        var products =await _productsRepository.GetAllEntitiesAsync(request.PaginationSpecParams);
        return _mapper.Map<PaginationReponse<ProductResponse>>(products);
    }
}
